    SerialPort sp = (SerialPort)sender;
    System.Threading.Thread.Sleep(500);
    
    var available = sp.BytesToRead; // check how many bytes are ready to be read
    if (available < 1)
        return;
    var buffer = new byte[available];
    sp.Read(buffer, 0, available);
    var indata = BitConverter.ToString(buffer); // convert bytes to a hex representation
    this.BeginInvoke(new SetTextDeleg(DisplayToUI), new object[] { indata });
