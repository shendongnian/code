        protected override async void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnBackKeyPress(e);
            await Task.Yield();
            MessagePrompt abortConfirm = new MessagePrompt();
            abortConfirm.Title = "Are you sure you want to go to Main Menu?";
            abortConfirm.Message = "All progress in the current game will be lost";
            Button confirmAbort = new Button();
            confirmAbort.Content = "Yes";
            confirmAbort.Click += (object sender3, RoutedEventArgs e3) =>
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            };
            Button cancelAbort = new Button();
            cancelAbort.Content = "No";
            cancelAbort.Click += (object sender2, RoutedEventArgs e2) =>
            {
                //abortConfirm.Hide();
            };
            abortConfirm.ActionPopUpButtons.Clear();
            abortConfirm.ActionPopUpButtons.Add(confirmAbort);
            abortConfirm.ActionPopUpButtons.Add(cancelAbort);
            abortConfirm.Show();
        }
