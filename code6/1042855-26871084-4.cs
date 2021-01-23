    public abstract class ObservableSerialPort : IDisposable
    {
        protected readonly SerialPort _serialPort;
    
        protected ObservableSerialPort(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            _serialPort = new SerialPort()
            {
                // common SerialPort construction code here. Removed to make answer more readable.
            };
    
            _serialPort.Open();
        }
    	
        public void Send(string text)
        {
            _serialPort.Write(text);
        }
    
        public void Send(byte[] text)
        {
            _serialPort.Write(text, 0, text.Length);
        }
    
        public void Dispose()
        {
            _serialPort.Close();
        }
    }
