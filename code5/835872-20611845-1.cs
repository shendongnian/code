        public void WriteToPort(string message)
        {
            // Throw exception if serialPort is not initialised.
            // Old code would have thrown from serialPort.Write
            if (serialPort == null) throw new InvalidOperationException();
            // Convert message to bytes
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
            // Convert message length to bytes
            byte[] lengthBytes = BitConverter.GetBytes(messageBytes.Length);
            
            // Convert message length bytes to big endian if needed
            if (BitConverter.IsLittleEndian) Array.Reverse(lengthBytes);
            // Open serial port if needed
            if (!serialPort.IsOpen) serialPort.Open();
            // Write length
            serialPort.Write(lengthBytes, 0, lengthBytes.Length);
            // Write message
            serialPort.Write(messageBytes, 0, messageBytes.Length);
        }
