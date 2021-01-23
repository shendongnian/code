    private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
    {
        FrameworkElement senderElement = sender as FrameworkElement;
        // If you need the clicked element:
        // Item whichOne = senderElement.DataContext as Item;
        FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
        flyoutBase.ShowAt(senderElement);
    }
    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        // get the clicked element:
        Item datacontext = (e.OriginalSource as FrameworkElement).DataContext as Item;
        await new MessageDialog("Edit").ShowAsync();
    }
