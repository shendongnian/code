        private void Next_Click(object sender, RoutedEventArgs e)
        {
            footerText.Text = "Waiting for dataRetreival";
            IsEnabled = false;
            Task.Factory.StartNew(() =>
            {
                SomeRandomTimeTakingMethod();
            }).ContinueWith(t =>
            {
                IsEnabled = true;
                footerText.Text = "Ready";
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void SomeRandomTimeTakingMethod()
        {
            Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(2, 5)));
        }
