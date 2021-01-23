    public override int Read(byte[] buffer, int offset, int count)
            {
                var resetEvent = new ManualResetEvent(false);
                var result = BeginRead(buffer, offset, count, OnComplete, resetEvent);
    
                var res = resetEvent.WaitOne(_readTimeout); // for example 100 ms
                if (res)
                    return EndRead(result);
                else
                {
                    m_ReceiveEventArgs.Dispose();
                    m_ReceiveEventArgs = null;
                    return EndRead(new StreamAsyncResult(new SocketAsyncEventArgs(), OnComplete));
                }
            }
