    public class EventThrottler
    {
        private Func<Task> next = null;
        private bool isRunning = false;
        public async void Run(Func<Task> action)
        {
            if (isRunning)
                next = action;
            else
            {
                isRunning = true;
                try
                {
                    await action();
                    while (next != null)
                    {
                        var nextCopy = next;
                        next = null;
                        await nextCopy();
                    }
                }
                finally
                {
                    isRunning = false;
                }
            }
        }
        private static Lazy<EventThrottler> defaultInstance =
            new Lazy<EventThrottler>(() => new EventThrottler());
        public static EventThrottler Default
        {
            get { return defaultInstance.Value; }
        }
    }
