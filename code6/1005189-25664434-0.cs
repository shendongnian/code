    private UsbDevice usb = new UsbDevice();
   
    
        if (usb != null && usb.myDevice != null)
                        {
                            byte[] data = new byte[usb.myDevice .nOutputReportLength];
        
                            data[0] = 0;    // The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            data[1] = b;
                            if (d != null)
                                Array.Copy(d, 0, data, 2, d.Length);
        
                            this.usb.myDevice .SendData(data);
                        }
                        else
                            MessageBox.Show("Device not found");
