    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("PageName", UriKind.Relative));
            base.OnBackKeyPress(e);
        }
