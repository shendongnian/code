    DataService.DataService service = new DataService.DataService(context);
    bool isAdded = false;
     // Used to signal the waiting test thread that a async operation have completed.    
            System.Threading.ManualResetEvent manualEvent = new ManualResetEvent(false);
            // Async callback events are anonomous and are in the same scope as the test code,    
            // and therefore have access to the manualEvent variable.    
            service.OnAddAsyncCompleted += (sender, e) =>
            {
                isAdded = true;
                manualEvent.Set();
                if (e.Error != null)
                {
                    exp = e.Error;
                }
                if (exp == null)
                {
                    if (e.Entity != null)
                    {
                        actual = (T)e.Entity;
                    }
                }
            };
            // Call the service method
            service.AddAsync(entity);
            manualEvent.WaitOne(30000, false); Thread.Sleep(10000);
            manualEvent.Reset();
