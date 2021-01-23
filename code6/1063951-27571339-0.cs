        static readonly TimeSpan duration = TimeSpan.FromSeconds(60);
        System.Diagnostics.Stopwatch sw;
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            // Once clicked then disabled
            startButton.IsEnabled = false;
            // Enable buttons required for answering 
            resultTextBox.IsEnabled = true;
            submitButton.IsEnabled = true;
            var viewModel = App.equation.GenerateEquation();
            this.DataContext = viewModel;
            result = App.equation.GetResult(viewModel);
            sw = System.Diagnostics.Stopwatch.StartNew();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
            // Reset message label
            if (message.Text.Length > 0)
            {
                message.Text = "";
            }
            // Reset result text box
            if (resultTextBox.Text.Length > 0)
            {
                resultTextBox.Text = "";
            }
        }
        private void timer_Tick(object sender, object e)
        {
            if (sw.Elapsed < duration)
            {
                Countdown.Text = (int)(duration - sw.Elapsed).TotalSeconds + " second(s) ";
            }
            else
            {
                Countdown.Text = "Times Up";
                timer.Stop();
                submitButton.IsEnabled = false;
                resultTextBox.IsEnabled = false;
                startButton.IsEnabled = true;
            }
        }
