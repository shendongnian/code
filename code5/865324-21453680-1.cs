            private void btnStartNewGame_Click(object sender, RoutedEventArgs e)
            {
            var app = App.Current as App;
            if (app.GamePage != null)
            Window.Current.Content = app.GamePage;
            }
