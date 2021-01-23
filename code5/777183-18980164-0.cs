    class Program
    {
        static SerialPort serialPort;
        static void Main(string[] args)
        {
            serialPort = new SerialPort("COM6", 1200, Parity.None, 8, StopBits.One);
            
            serialPort.Open();
            if (serialPort.IsOpen)
            {
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
            Thread.Sleep(10000);
        }
        static void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var length = serialPort.BytesToRead;
            byte[] buffer = new byte[length];
            serialPort.Read(buffer, 0, length);
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer.Length >= 2)
                {
                    Console.WriteLine("Ok with = > " + buffer.ToString());
                }
            }
        }
    }
