    var listView = new ListView();
    foreach (var item in something)
    {
        var image = new Image();
        image.Source = ...;
        image.Stretch = Stretch.None;
    
        var label = new Label();
        label.Content = "Test 123";
    
        DockPanel.SetDock(image, Dock.Left);
        DockPanel.SetDock(label, Dock.Right);
    
        var dockPanel = new DockPanel();
        dockPanel.Children.Add(image);
        dockPanel.Children.Add(label);
        var item = new ListViewItem();
        item.Content = dockPanel;
    
        listView.Items.Add(item);
    }
