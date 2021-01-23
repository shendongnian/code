    using (UsbEndpointWriter writer = device.OpenEndpointWriter(WriteEndpoint))
    {
        UsbTransfer usbTransfer = null;
        try
        {
            // Code to do transfer here .. not shown as not pertinent here..
        }
        finally
        {
            if (usbTransfer != null)
            {
                // **** Start of code added to fix ObjectDisposedException
                if (!usbTransfer.IsCancelled || !usbTransfer.IsCompleted)
                {
                    usbTransfer.Cancel();
                }
                // **** End of code added to fix ObjectDisposedException
                usbTransfer.Dispose();
            }
        }
    }
