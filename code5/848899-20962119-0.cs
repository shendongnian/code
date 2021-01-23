    object myLock = new object();
    void IBSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        lock(myLock)
        {
            while (BytesToRead > 0)
            {
                ProcessByte((byte)ReadByte());
            }
        }
    }
