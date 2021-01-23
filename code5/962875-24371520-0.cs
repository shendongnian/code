        Task.Factory.StartNew(() =>
        {
            System.Threading.Thread.Sleep(Interval);
            TheMethod();
        });
