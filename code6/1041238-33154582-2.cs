     private void AddDataThreadLoop()
        {
            while (!_shouldStop)
            {
                chChannels[1].Invoke(addDataDel);
    
                // Sleeep thread for 100ms
                Thread.Sleep(100); 
            }
        }
    
 
