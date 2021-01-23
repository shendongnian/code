    private void KinectTileButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (KinectTileButton)e.Source;
        var wineModel = button.Tag as WineModel;
        var selectionDisplay = new SelectionDisplay(wineModel);
        this.kinectRegionGrid.Children.Add(selectionDisplay);
        switch(button.Label.ToString())
        {
            case "5":
                KinectTileButton_Click_1(sender, e);
                break;
        }
        e.Handled = true;
    }
