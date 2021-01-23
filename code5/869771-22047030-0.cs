    SerialPort sp = (SerialPort) sender;
    // string s = sp.ReadExisting();
    // labelSerialMessage.Invoke(this.showSerialPortDelegate, new object[] { s });
    int length = sp.BytesToRead;
    byte[] buf = new byte[length];
    sp.Read(buf, 0, length);
    System.Diagnostics.Debug.WriteLine("Received Data:" + buf);
    labelSerialMessage.Invoke(this.showSerialPortDelegate, new object[] { 
        System.Text.Encoding.Default.GetString(buf, 0, buf.Length) });
