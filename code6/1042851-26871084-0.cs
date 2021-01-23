    public abstract class ObservableSerialPort : IDisposable
    {
        protected readonly SerialPort _serialPort;
    
        protected ObservableSerialPort(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            _serialPort = new SerialPort()
            {
                PortName = portName,
                BaudRate = baudRate,
                Parity = parity,
                DataBits = dataBits,
                StopBits = stopBits,
                DtrEnable = true,
                RtsEnable = true,
                Encoding = new ASCIIEncoding(),
                ReadBufferSize = 4096,
                ReadTimeout = 10000,
                WriteBufferSize = 2048,
                WriteTimeout = 800,
                Handshake = Handshake.None,
                ParityReplace = 63,
                NewLine = "\n",
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
