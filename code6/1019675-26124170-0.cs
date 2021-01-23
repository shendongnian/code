        delegate void SerialPortOnDataReceivedDelegate(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs);
        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            if (InvokeRequired)
                BeginInvoke(new SerialPortOnDataReceivedDelegate(SerialPortOnDataReceived), new object[] { sender, serialDataReceivedEventArgs });
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
                }
            }
        }
        public byte[] FromHex(string aHex)
        {
            aHex = aHex.Replace(" ", "");
            byte[] raw = new byte[aHex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(aHex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
