        public void WriteToPort(string message)
        {
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
            byte[] lengthBytes = new byte[4];
            int length = messageBytes.Length;
            lengthBytes[0] = (byte)(length & 0xFF000000);
            lengthBytes[1] = (byte)(length & 0x00FF0000);
            lengthBytes[2] = (byte)(length & 0x0000FF00);
            lengthBytes[3] = (byte)(length & 0x000000FF);
            
            if (serialPort != null && !serialPort.IsOpen)
            {
                serialPort.Open();
            }
            serialPort.Write(lengthBytes, 0, lengthBytes.Length);
            serialPort.Write(messageBytes, 0, messageBytes.Length);
        }
