/*
 * Created by SharpDevelop.
 * User: oliver
 * Date: 07/06/2015
 * Time: 13:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.IO.Ports;

namespace SerialMonitor4Arduino
{
	class Program
	{
		static string portName;
	    static int baudRate;
		static string parity;
		static int dataBits;
		static string stopBits;
		
		//Thread readThread;
		//readThread = new Thread(); //PROVA: new Thread(Read)
		
		//initialize serial port
		
		
		public static void Main()
		{
		    SerialPort serialPort;
		    serialPort = new SerialPort();
		    
		    Console.WriteLine("Serial Monitor For Arduino V0.1");
			
			portSetup(serialPort);
			
			repilogue(serialPort);
			
			closePortIfOpen(serialPort);
			
			startReading(serialPort);
			
			
			
			
		}
		
		public static void portSetup(SerialPort sp)
		{
			setPortName(sp);
			setBaudRate(sp);
			setParity(sp);
			setDataBits(sp);
			setStopBits(sp);
		}
		
		public static void setPortName(SerialPort serialportPN)
		{
			//Set the portname
			Console.Write("Insert Port Name(Usually COM#): ");
			portName = Console.ReadLine();
			serialportPN.PortName = portName;
			//Console.WriteLine("Successfully set Port Name to "+serialportPN.PortName.ToString()+" !");
		}
		public static void setBaudRate(SerialPort serialportBR)
		{
			//Set the baud rate
			Console.Write("Insert Baud Rate: ");
			baudRate = int.Parse(Console.ReadLine());
			serialportBR.BaudRate = baudRate;
			//Console.WriteLine("Successfully set Baud Rate to "+serialportBR.BaudRate.ToString()+" !");
		}
		public static void setParity(SerialPort serialportP)
		{
			//set the parity
			Console.Write("Insert Parity(Usually  for Arduino is None): ");
			parity = Console.ReadLine();
			if(parity == "None")
			{
				serialportP.Parity = Parity.None;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			if(parity == "none")
			{
				serialportP.Parity = Parity.None;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			if(parity == "Space")
			{
				serialportP.Parity = Parity.Space;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			if(parity == "space")
			{
				serialportP.Parity = Parity.Space;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			if(parity == "Mark")
			{
				serialportP.Parity = Parity.Mark;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			if(parity == "mark")
			{
				serialportP.Parity = Parity.Mark;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			if(parity == "Odd")
			{
				serialportP.Parity = Parity.Odd;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			if(parity == "odd")
			{
				serialportP.Parity = Parity.Odd;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			if(parity == "Even")
			{
				serialportP.Parity = Parity.Even;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			if(parity == "even")
			{
				serialportP.Parity = Parity.Even;
				//Console.WriteLine("Successfully set Parity to "+serialportP.Parity.ToString()+" !");
			}
			
			//FIXME: this else cause an error
//			else
//			{
//				Console.WriteLine("Error!");
//				Console.WriteLine("Redo the Setup...");
//				Main();
//			}
		}
		public static void setDataBits(SerialPort serialportDB)
		{
			//set the data bits
			Console.Write("Insert Data Bits Number: ");
			dataBits = int.Parse(Console.ReadLine());
			serialportDB.DataBits = dataBits;
			//Console.WriteLine("Successfully set Data Bits to "+serialportDB.DataBits.ToString()+" !");
		}
		public static void setStopBits(SerialPort serialportSB)
		{
			//set stop bits;
			Console.Write("Insert Stop Bits(Usually One for Arduino): ");
			stopBits = Console.ReadLine().ToString();
			if(stopBits == "None")
			{
				serialportSB.StopBits = StopBits.None;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if(stopBits == "none")
			{
				serialportSB.StopBits = StopBits.None;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if (stopBits == "One")
			{
				serialportSB.StopBits = StopBits.One;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if (stopBits == "one")
			{
				serialportSB.StopBits = StopBits.One;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if (stopBits == "1")
			{
				serialportSB.StopBits = StopBits.One;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if(stopBits =="OnePointFive")
			{
				serialportSB.StopBits = StopBits.OnePointFive;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if(stopBits =="onepointfive")
			{
				serialportSB.StopBits = StopBits.OnePointFive;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if(stopBits =="1.5")
			{
				serialportSB.StopBits = StopBits.OnePointFive;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if(stopBits =="1,5")
			{
				serialportSB.StopBits = StopBits.OnePointFive;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if(stopBits =="Two")
			{
				serialportSB.StopBits = StopBits.Two;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if(stopBits =="two")
			{
				serialportSB.StopBits = StopBits.Two;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			if(stopBits =="2")
			{
				serialportSB.StopBits = StopBits.Two;
				//Console.WriteLine("Successfully set Parity to "+serialportSB.StopBits.ToString()+" !");
			}
			//FIXME: this else cause an error
//			else
//			{
//				Console.WriteLine("Error!");
//				Console.WriteLine("Redo the Setup...");
//				Main();
//			}
		}
		
		public static void repilogue(SerialPort serialPort)
		{
			Console.WriteLine();
			Console.WriteLine("Port Name is set to: "+ serialPort.PortName);
			Console.WriteLine("Baud Rate is set to: "+ serialPort.BaudRate);
			Console.WriteLine("Parity is set to: "+ serialPort.Parity);
			Console.WriteLine("Data bits is set to: "+ serialPort.DataBits);
			Console.WriteLine("Stop bits is set to: "+ serialPort.StopBits);
			Console.WriteLine();
		}
		
		public static void closePortIfOpen(SerialPort serialPort)
		{
			if (serialPort.IsOpen) 
			{
				serialPort.Close();
			}
		}
		
		public static void startReading(SerialPort serialPort)
		{
			Console.Write("Are you sure you want continue with this setup?(yes/no) ");
			string start = Console.ReadLine();
			if(start == "yes")
			{
				serialPort.Open();
				
				Console.WriteLine();
				Console.WriteLine("To start reading type Enter.");
				Console.WriteLine();
				Console.WriteLine("To quit the connection type exit.");
				
				if(Console.ReadLine() == "exit")
				{
				    Main();
				}
				
				while(serialPort.IsOpen)
			    {
				    string message = serialPort.ReadLine();
				    Console.WriteLine(message);
				    serialPort.ReadLine();
				    
				    
			    }
			}
			if(start == "y")
			{
				serialPort.Open();
				
				Console.WriteLine("For quit the connection type exit.");
				if(Console.ReadLine() == "exit")
				{
				    Main();
				}
				
				while(serialPort.IsOpen)
			    {
				    string message = serialPort.ReadLine();
				    Console.WriteLine(message);
				    serialPort.ReadLine();
				    
				    
			    }
			}
			if(start == "no")
			{
				Console.WriteLine("Restarting application...");
				Main();
			}
			if(start == "n")
			{
				Console.WriteLine("Restarting application...");
				Main();
			}
		}
		
	}
}