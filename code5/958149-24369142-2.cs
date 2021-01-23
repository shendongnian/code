        private IAsyncOperation<IUICommand> dialogTask;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dlg = new MessageDialog("This will close after 5 seconds");
            try
            {
                dialogTask = dlg.ShowAsync();
            }
            catch (TaskCanceledException)
            {
                //this was cancelled
            }
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(5);
            dt.Tick += dt_Tick;
            dt.Start();
        }
        void dt_Tick(object sender, object e)
        {
            (sender as DispatcherTimer).Stop();
            dialogTask.Cancel();
        }
