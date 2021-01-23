     private void btnStartNewGame_Click(object sender, RoutedEventArgs e)
                {
                    var app = App.Current as App;
                    if (app.GamePage != null)
                    { app.GamePage = null; app.GamePage = new GamePage(string.Empty); }
                    else { app.GamePage = new GamePage(string.Empty); }
                    Window.Current.Content = app.GamePage;
                }
