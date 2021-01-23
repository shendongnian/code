    private async void LaunchContosoNewProductsButton_Click(object sender, RoutedEventArgs rea)
    {
        // Launch URI.
        Windows.System.Launcher.LaunchUriAsync(new System.Uri("contoso:NewProducts"));
    }
