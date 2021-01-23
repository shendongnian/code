    using System.IO.Ports;
    public void TestSerialPort()
    {
    SerialPort serialPort = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);
    serialPort.Open();
    byte[] data = new byte[] { 1, 2, 3, 4, 5 };
    serialPort.Write(data, 0, data.Length);
    serialPort.Close();
    }
   
