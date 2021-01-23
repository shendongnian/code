    // Threaded method
    private void Receive()
    {
        // Don't know how much of a buffer you need
        byte[] dataIn = byte[1000];
        while (acceptSocket.Connected)
        {
            // Exception handling so you either end the thread or keep processing data
            try
            {
                int bytesRead = acceptSocket.Read(dataIn);
                if (bytesRead != -1)
                {
                    // Process your data
                }
                else
                {
                    // -1 Bytes read should indicate the client shutdown on their end
                    break;
                }
            }
            catch(SocketException se)
            {
                // You could exit this loop depending on the SocketException
            }
            catch(ThreadAbortException tae)
            {
                // Exit the loop
            }
            catch (Exception e)
            {
                // Handle exception, but keep reading for data
            }
        }
        
        // You have to check in case the socket was disposed or was never successfully created
        if (acceptSocket != null)
        {
            acceptSocket.Close();
        }
    }
    // This is the stop method if you press your stop button
    private void Stop()
    {
        // Aborts your read thread and the socket should be closed in the read thread.  The read thread should have a ThreadState.Stopped if the while loop was gracefully ended and the socket has already been closed
        if (readThread != null && readThread.ThreadState != ThreadState.Stopped)
        {
            readThread.Abort();
        }
    }
