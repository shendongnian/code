    ContextMenu contextMenu = new ContextMenu();
    MenuItem xMenuItem = new MenuItem();
    
    StackPanel panel = new StackPanel() { Orientation = Orientation.Horizontal };
    
    Label label = new Label();
    TextBox xTextBox = new TextBox();       
    
    panel.Children.Add(label);
    panel.Children.Add(xTextBox);
    
    xMenuItem.Header = panel;
    
    contextMenu.Items.Add(xMenuItem);
