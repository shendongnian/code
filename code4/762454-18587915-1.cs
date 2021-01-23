        async Task WaitForItToWork()
        {
            await Task.Run(() =>
            {
                bool succeeded = false;
                while (!succeeded)
                {
                    // do work
                    succeeded = outcome; // if it worked, make as succeeded, else retry
                    System.Threading.Thread.Sleep(1000); // arbitrary sleep
                }
            });
        }
