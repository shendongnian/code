            Task<System.IO.MemoryStream> initialRun = new Task<System.IO.MemoryStream>(() =>
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                // use stream
                return stream;
            });
            initialRun.ContinueWith(new Action<Task<System.IO.MemoryStream>>((stream) =>
            {
                stream.Dispose();
            }), 
            TaskScheduler.FromCurrentSynchronizationContext());
            initialRun.Start();
