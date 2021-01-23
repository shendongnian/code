    using System;
    using System.Threading;
    using System.IO.Ports;
    
    class PortDataReceived
    {
    
        public static void Main()
        {
            SerialPort mySerialPort = new SerialPort("COM2");
    
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.RequestToSend;
    
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    
            mySerialPort.Open();
    
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            Console.ReadKey();
    
            mySerialPort.Close();
    
        }
    
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
        //   
            string indata = string.Empty;
            SerialPort sp = (SerialPort)sender;
            **Thread.Sleep(3000);**
                     indata = sp.ReadExisting();
                     
                
            Console.WriteLine("Data Received:");
            Console.WriteLine(indata);
        }
    }
