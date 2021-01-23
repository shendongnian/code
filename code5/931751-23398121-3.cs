    public class Worker
    {
        public Worker(Action<string>action)
        {
            Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    ++i;
                    Task.Run(() => { action("Current value " + i); });
                    Task.Run(() =>
                    {
                        // doing some work here
                    });
                    Thread.Sleep(1000);
                }
            });
        }
    }
