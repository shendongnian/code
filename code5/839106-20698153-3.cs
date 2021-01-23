    private sealed class Receiver
    {
        private void Run()
        {
            try
            {
                // ShutdownEvent is a ManualResetEvent signaled by
                // Client when its time to close the socket.
                while (!ShutdownEvent.WaitOne(0))
                {
                    try
                    {
                        // We could use the ReadTimeout property and let Read()
                        // block.  However, if no data is received prior to the
                        // timeout period expiring, an IOException occurs.
                        // While this can be handled, it leads to problems when
                        // debugging if we are wanting to break when exceptions
                        // are thrown (unless we explicitly ignore IOException,
                        // which I always forget to do).
                        if (!_stream.DataAvailable)
                        {
                            // Give up the remaining time slice.
                            Thread.Sleep(1);
                        }
                        else if (_stream.Read(_data, 0, _data.Length) > 0)
                        {
                            // Raise the DataReceived event w/ data...
                        }
                        else
                        {
                            // The connection has closed gracefully, so stop the
                            // thread.
                            ShutdownEvent.Set();
                        }
                    }
                    catch (IOException ex)
                    {
                        // Handle the exception...
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception...
            }
            finally
            {
                _stream.Close();
            }
        }
    }
