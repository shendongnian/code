    public void Form_Load()
    {
        // do some stuff on the gui-thread
        // i need to do something that takes a long time:
        ThreadPool.QueueUserWorkItem((state) =>
        {
            // i'll execute it on the ThreadPool
            // Long running code....
            // update results in mainform on gui thread.
            Invoke(new Action( delegate
            {
                // because the invoke will execute this on the gui-thread, you'll able to update controls.
                // update my gui controls.             
                DataGrid.Source = myReceiveDataThing;
            }));
        }
    }
