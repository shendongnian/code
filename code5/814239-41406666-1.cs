    using System.IO.Ports;
    using System.Threading;
    
    private SerialPort _serialPort;
    
    	_serialPort = new SerialPort(comboBoxEdit3.Text, 115200);
    
        Thread.Sleep(100);
        _serialPort.Open();
        Thread.Sleep(100);
        _serialPort.Write("AT+CMGF=1\r");
        Thread.Sleep(100);
        _serialPort.Write("AT+CMGS=\"" + number + "\"\r\n");
        Thread.Sleep(100);
        _serialPort.Write(messages + "\x1A");
        Thread.Sleep(300);
    
        MessageBox.Show("Password Sent on your Mobile !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
        _serialPort.Close();
