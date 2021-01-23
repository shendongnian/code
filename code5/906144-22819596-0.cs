    static string ReadFromStream(int initialTimeout, int subsequentTimeout)
        {
            // Initialize output
            string output = null;
            try
            {
                // Set initial read timeout -- This is needed because occasionally
                // it takes a while before data starts flowing
                stream.ReadTimeout = initialTimeout;
                while (stream.CanRead)
                {
                    // Read bytes in from stream
                    readBuffer = new byte[tcpClient.ReceiveBufferSize];
                    stream.Read(readBuffer, 0, tcpClient.ReceiveBufferSize);
                    // Convert the bytes to string and save to output
                    output = string.Format("{0}{1}", output, Encoding.ASCII.GetString(readBuffer).Trim());
                    // Set subsequent read timeout
                    stream.ReadTimeout = subsequentTimeout;
                }
            }
            // Since we don't know when the output will end, we wait for, and catch the timeout
            catch (IOException) { }
            // Return output
            return output;
        }
