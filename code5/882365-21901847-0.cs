      protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                if (e.NavigationMode == NavigationMode.Back)
                {
                    App.Quit();
                }
            }
    
            protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
            {
                App.Quit();
            }
