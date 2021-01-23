    // Start the keep alive Thread
        _keepAliveThread = new Thread(
            argument =>
            {
                Service service = argument as Service;
                while (true)
                {
                    Thread.Sleep(60000);
                    try
                    {
                        service.Ping();
                        Trace.WriteLine("Ping called on the Service");
                    }
                    catch
                    {
                        Trace.WriteLine("Ping failed");
                    }
                }
            }, _service);
        _keepAliveThread.Start();
