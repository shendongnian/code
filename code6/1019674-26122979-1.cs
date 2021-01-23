    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
    {
        if (InvokeRequired)     
        {                
            BeginInvoke(new Closure(() => { SerialPortOnDataReceived(sender, serialDataReceivedEventArgs); }));     
        }
        else
        {
            if (_serialPort.BytesToRead > 0)
            {
                //hex = "";  <- Without this different weight values appears one after another. If applied then happens what explained above.
                while (_serialPort.BytesToRead > 0) //<-- repeats until the In-Buffer is empty
                {                        
                    hex += string.Format("{0:X2} ", _serialPort.ReadByte());                        
                }
                byte[] data = FromHex(hex.Trim());
                textBox1.Text = Encoding.ASCII.GetString(data).Trim();
                _serialPort.OnDataReceived-=SerialPortOnDataReceived; // <---add this
            }
        }
    }
