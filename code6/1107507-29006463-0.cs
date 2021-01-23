    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        Page2 destinationPage = e.Content as Page2;
        if (destinationPage != null)
        {
            destinationPage.FirstName = txtFN.Text;
        }
    }
