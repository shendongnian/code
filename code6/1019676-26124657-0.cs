            string hex = "";
            private delegate void Closure();        
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
                        Thread.Sleep(200);  //<-- Add some delay
                        hex = "";
                        
                        while (_serialPort.BytesToRead > 0) //<-- repeats until the In-Buffer is empty
                        {                        
                            hex += string.Format("{0:X2} ", _serialPort.ReadByte());                        
                        }
    
                        byte[] data = FromHex(hex.Trim());                    
                        textBox1.Text = Encoding.ASCII.GetString(data).Trim();                    
                    }
                }
            }
