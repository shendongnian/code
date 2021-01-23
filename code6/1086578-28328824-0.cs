    private void DeploySite()
    {
        // Fire up a new Task
        Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    int i1 = i;
                    // Dispatch
                    System.Windows.Application.Current.Dispatcher.BeginInvoke(
                        new Action(() => Sequence.Add(i1)), null);
                    Thread.Sleep(100);
                }
            });
    }
