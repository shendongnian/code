    private void CollectionDeviceSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0 && e.AddedItems[0] is CollectionDevice)
        {
            // Assign the view models SelectedCollectionDevice to the device selected in the combo box.
            var device = e.AddedItems[0] as CollectionDevice;
            ((Models.UserPreferences)this.DataContext).SelectedCollectionDevice = device;
            // Check if Other is selected. If so, we have to present additional options.
            if (device.Name == "Other")
            {
                OtherCollectionDevicePanel.Visibility = Visibility.Visible;
            }
            else if (OtherCollectionDevicePanel.Visibility == Visibility.Visible)
            {
                OtherCollectionDevicePanel.Visibility = Visibility.Collapsed;
            }
        }
    }
