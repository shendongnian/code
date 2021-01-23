        using System.Threading;
        ManualResetEventSlim waitEvent = new ManualResetEventSlim(false); // start in the unsignaled state
        async void Application_Closing(object sender, ClosingEventArgs e)
        {
            await MyLoop();    // execute asynchronously
            waitEvent.Wait();  // wait for a signal to continue
        }
        void Application_Activated(object sender, ActivatedEventArgs e)
        {
            waitEvent.Reset(); // set unsignaled
        }
        Task MyLoop()
        {
            while(true)
            {
                if(condition)
                    break;
            }
            waitEvent.Set(); // signal the app to continue
        }
