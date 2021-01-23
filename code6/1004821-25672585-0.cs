    while (AlertIsActive)
        {
            if (this.Dispatcher.HasShutdownStarted ||
                this.Dispatcher.HasShutdownFinished)
            {
                break;
            }
            this.Dispatcher.Invoke(
                DispatcherPriority.Background,
                new ThreadStart(delegate { }));
            Thread.Sleep(20);
        }
