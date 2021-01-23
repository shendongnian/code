    private void KinectTileButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (KinectTileButton)e.Source;
        if(button.Label.ToString() == "Koala2")
           Method1(<somearguments>);
        else
           Method2(button.Tag as WineModel);
    
        e.Handled = true;//if it must happen for all label values.
    }
  
    public void Method1(<some parameters>) {
      //DoSomething
    }
    
    public void Method2(WineModel wineModel) {
      var selectionDisplay = new SelectionDisplay(wineModel);
        this.kinectRegionGrid.Children.Add(selectionDisplay);
    }
