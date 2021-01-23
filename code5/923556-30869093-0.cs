        private void ReadCallback(IAsyncResult result)
    {
        try
        {
            int read;
            NetworkStream networkStream;
            try
            {
                networkStream = tcpClient.GetStream();
                read = networkStream.EndRead(result);
            }
            catch (Exception ex)
            {
                Close();
                return;
            }
            if (read == 0)
            {
                Close();
                return;
            }
            if (!_isConnected)
            {
                _isConnected = true;
                _waitEvent.Set();
            }
            try
            {
                byte[] buffer = result.AsyncState as byte[];
                try
                {
                    ParseData(buffer, read);
                }
                catch (Exception e1)
                {
                }
                //Then start reading from the network again.
                networkStream.BeginRead(buffer, 0, buffer.Length, ReadCallback, buffer);
            }
            catch (Exception ex)
            {
                Close();
                return;
            }
        }
        catch (Exception ex)
        {
        }
    }
