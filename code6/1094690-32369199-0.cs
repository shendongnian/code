         while (!_interrupt && !_complete)
            {
                if (_q.Count > 0)
                {
                    buffer = _q.Dequeue();
                    source.Write(buffer, 0, buffer.Length);
        
    // Check is playing
        if (soundOut.PlaybackState == PlaybackState.Stopped)
                        soundOut.Play();
        
                    System.Console.WriteLine("Buffer written {0} bytes", buffer.Length);
                    Thread.Sleep(10);
                }
            }
