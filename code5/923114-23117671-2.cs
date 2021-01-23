    private void KinectTileButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (KinectTileButton)e.Source;
        if(button.Label.ToString() == "Koala2")
        {
                KinectTileButton_Click_1(sender, e);
                return;//get out of this method.
        }
        var wineModel = button.Tag as WineModel;
        var selectionDisplay = new SelectionDisplay(wineModel);
        this.kinectRegionGrid.Children.Add(selectionDisplay);
    
        e.Handled = true;
    }
