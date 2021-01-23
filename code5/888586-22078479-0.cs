    using System.IO.Ports;
    public void TestSerialPort()
    {
        SerialPort serialPort = new SerialPort("COM1", 65535, Parity.None, 8, StopBits.One);
        byte[] data = new byte[] { 1, 2, 3, 4, 5 };
        serialPort.Write(data, 0, data.Length);
        serialPort.Close();
    }
