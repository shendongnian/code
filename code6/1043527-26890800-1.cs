    page.NavigationService.Navigate(new Uri("/Views/Page.xaml?parameter=test", UriKind.Relative));
    // and ..
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        // NavigationEventArgs returns destination page
        Page destinationPage = e.Content as Page;
        if (destinationPage != null) {
    
            // Change property of destination page
            destinationPage.PublicProperty = "String or object..";
        }
    }
