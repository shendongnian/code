    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
    // NavigationEventArgs returns destination page
    Page destinationPage = e.Content as Page;
    if (destinationPage != null) 
    {
        // Change property of destination page
        destinationPage.PublicProperty = "String or object..";
