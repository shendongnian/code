    private void myPopup_Close(object sender, System.EventArgs e)
    {
       // get current Page
       var currentPage = ((App.Current as App).RootVisual as PhoneApplicationFrame).Content as PhoneApplicationPage;
        // hide popup
        currentPage.ApplicationBar.IsVisible = true;
    }
