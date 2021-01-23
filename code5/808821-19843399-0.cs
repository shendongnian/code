        public void DoSomething()
        {
            Console.WriteLine("> Session opened at {0}", DateTime.Now);
            callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            Timer = new Timer(1000);
            Timer.Elapsed += OnTimerElapsed;
            Timer.Enabled = true;
        }
        void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            callback.OnCallback();
        }
