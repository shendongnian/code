    private Constructor()
    {
        Map my_map = new Map();
        my_map.Name= "map1";
        my_map.mode = "AerialWithLabels";
        my_map.Height = 300;
        my_map.Margin = new Thickness(-12,0,0,0);
        my_map.VerticalAlignment = System.Windows.VerticalAlignment.Top;
        my_map.HorizontalAlignment= System.Windows.HorizontalAlignment.Left;
        ContentPanel.Children.Add(my_map);
    }
        
