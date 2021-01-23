        private void Start_Click(object sender, RoutedEventArgs e)
        {
            StartTimer();
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.IsEnabled = false;
        }
