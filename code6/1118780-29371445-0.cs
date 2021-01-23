        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
            {
                updater.CancelAsync();
                while (updater.IsBusy)
                {
                    Thread.Sleep(100);
                }
    //run code to delete the files after the worked has stopped
    }
