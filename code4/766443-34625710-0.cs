      public void StartReadingAsync()
        {
            // Debug.WriteLine("Pipe " + FullPipeNameDebug() + " calling ReadAsync");
            // okay we're connected, now immediately listen for incoming buffers
            //
            byte[] pBuffer = new byte[MaxLen];
            m_pPipeStream.ReadAsync(pBuffer, 0, MaxLen).ContinueWith(t =>
            {
                // Debug.WriteLine("Pipe " + FullPipeNameDebug() + " finished a read request");
                // before we call the user back, start reading ANOTHER buffer, so the network stack
                // will have something to deliver into and we don't keep it waiting.
                // We're called on the "anonymous task" thread. if we queue another call to
                // the pipe's read, that request goes down into the kernel, onto a different thread
                // and this will be called back again, later. it's not recursive, and perfectly legal.
                int ReadLen = t.Result;
                if (ReadLen == 0)
                {
                    Debug.WriteLine("Got a null read length, remote pipe was closed");
                    if (PipeClosedEvent != null)
                    {
                        PipeClosedEvent(this, new EventArgs());
                    }
                    return;
                }
                // lodge ANOTHER read request BEFORE calling the user back. Doing this ensures
                // the read is ready before we call the user back, which may cause a write request to happen,
                // which will zip over to the other end of the pipe, cause a write to happen THERE, and we won't be ready to receive it
                // (perhaps it will stay stuck in a kernel queue, and it's not necessary to do this)
                //
                StartReadingAsync();
                if (PipeReadDataEvent != null)
                {
                    PipeReadDataEvent(this, new PipeReadEventArgs(pBuffer, ReadLen));
                }
                else
                {
                    Debug.Assert(false, "something happened");
                }
            });
        }
