    void SendCommand(string command) {
        serialPort.Write(command + "\r");
    
        // Do not put here an arbitrary wait, check modem's response
        // Reading from serial port (use timeout).
        CheckResponse();
    }
    
    serialPort.DataBits = 8;
    serialPort.Parity = Parity.None;
    serialPort.StopBits = StopBits.One;
    serialPort.BaudRate = 9600;
    serialPort.DtrEnable = true;
    serialPort.RtsEnable = true;
    serialPort.Encoding = Encoding.GetEncoding("iso-8859-1");
    
    serialPort.DiscardInBuffer();
    serialPort.DiscardOutBuffer();
    
    SendCommand("AT"); // "Ping"
    SendCommand("AT+CMGF=1"); // Message format
    SendCommand("AT+CSCS=\"PCCP437\""); // Character set
    
    SendCommand("AT+CMGS=\"123456\"") // Phone number
    SendCommand("hello" + "\x1A"); // Message
