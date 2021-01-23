    public void sendUsbData(byte _txData)
    {
      byte[] txData = new byte[this.usb.SpecifiedDevice.OutputReportLength];
      txData[1] = 0x50; // 0x50 = loopback command. Element 0 is always 0x00
      int pos = 2;
      foreach (byte b in _flashData)
      {
        txData[pos] = b;
        pos++;
      }
      // reset member wait handle
      waitHandle = new AutoResetEvent(false); 
      this.usb.SpecifiedDevice.SendData(txData);
    }
    private void usb_OnDataRecieved(object sender, DataRecievedEventArgs args)
    {
      this.ParseReceivePacket(args.data); // Format to string and print to textbox
      
      // signal member wait handle
      waitHandle.Set();
    }
