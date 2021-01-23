            try
            {
                try
                {
                    try
                    {
                        // Close the stream
                        var stream = _tcpClient.GetStream();
                        if (stream != null)
                            stream.Close();
                    }
                    catch { }
                    try
                    {
                        // Close the socket
                        if (_tcpClient.Client != null)
                            _tcpClient.Client.Close();
                    }
                    catch { }
                    // Close the client
                    _tcpClient.Close();
                    _tcpClient = null;
                }
                catch { }
                if (_device != null)
                {
                    _device.Dispose();
                    _device = null;
                }
            }
            catch { }
            System.Threading.Thread.Sleep(1000);
