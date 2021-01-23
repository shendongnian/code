    private void btnDoSomething()
    {
        try
        {
            string nameThread = "testThreadDoSomething";
            var newThread = new Thread(delegate() { this.DoSomething(nameThread); });
            newThread.IsBackground = true;
            newThread.Name = nameThread;
            newThread.Start();
            //Prevent optimization from setting the field before calling Start
            Thread.MemoryBarrier();
        }
        catch (Exception ex)
        {
            
        }
    }
    public void DoSomething(string threadName)
    {
        bool ownsMutex;
        using (Mutex mutex = new Mutex(true, threadName, out ownsMutex))
        {
            if (ownsMutex)
            {
                Thread.Sleep(300000); // 300 seconds
                if (Monitor.TryEnter(this, 300))
                {
                    try
                    {
                        // Your Source
                    }
                    catch (Exception e)
                    {
                        string mensagem = "Error : " + e.ToString();
                    }
                    finally
                    {
                        Monitor.Exit(this);
                    }
                }
                //mutex.ReleaseMutex();
            }
        }
    }
