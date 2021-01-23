    private void StackPanel_Tap_1(object sender, GestureEventArgs e)
    {
        StackPanel panel = sender as StackPanel;
        foreach( var child in panel.Children)
        {
            if ( child is HubTile)
            {
                // This hubtile is the control inside StackPanel. 
                HubTile hubTile = child as HubTile;
                // Now you can access it properties.
                string name = hubTile.Name;
            }
        }
    }
