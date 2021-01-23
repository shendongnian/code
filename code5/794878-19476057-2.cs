        SemaphoreSlim sem = new SemaphoreSlim(1);
        private async Task TestAwaitTaskArrayAsync()
        {
            await sem.WaitAsync();
            try {
             Task[] taskArray = new Task[]
               {
                 Task.Run(() =>
                 {
                     SomeMethod1();
                 }),
                 Task.Run(() =>
                 {
                     SomeMethod2();
                 })
               };
             }
             await Task.WhenAll(taskArray);
            }
            finally { sem.Release(); }
        }
