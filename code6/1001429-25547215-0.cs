    public static Thread Schedule(Action action, int delaysecs)
    {
        new Thread(new ThreadStart(() =>
        {
            DateTime dateTime = DateTime.Now;
            while (true) {
                if (DateTime.Now > dateTime)
                {
                    action();
                    dateTime.AddSeconds(delaysecs);
                }
                Thread.Sleep(1000); //Adjust for accuracy
            }
        })).Start();
    }
