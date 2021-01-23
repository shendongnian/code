    public TreeViewItem newItem = new TreeViewItem() //Child Node
    {
        Header = new StackPanel 
        {
            Orientation = Orientation.Horizontal,
            Children =
            {
                new Border 
                {
                    Width = 12,
                    Height = 14,
                    Background = Brushes.Blue,
                    BorderThickness = new Thickness(1.0),
                    BorderBrush = Brushes.Black
                },
                new Label 
                {
                    Content = "Node1",
                    Foreground = Brushes.Black,
                }
            }
        }
    };
    private void AddItem_Click(object sender, RoutedEventArgs e)
    {
        // Set Selected handler on Selected event
        newItem.Selected += new RoutedEventHandler(newItem_Selected);
        // Set Unselected handler on Unselected event
        newItem.Unselected += new RoutedEventHandler(newItem_Unselected);
        // Add your item
        MyTreeView.Items.Add(newItem);
    }
    // Set the black color for foreground
    private void newItem_Unselected(object sender, RoutedEventArgs e) 
    {
        TreeViewItem MyTreeViewItem = sender as TreeViewItem;
        StackPanel MyStackPanel = MyTreeViewItem.Header as StackPanel;
        Label MyLabel = MyStackPanel.Children[1] as Label;
        MyLabel.Foreground = Brushes.Black;
    }
    // Set the white color for foreground
    private void newItem_Selected(object sender, RoutedEventArgs e)
    {
        TreeViewItem MyTreeViewItem = sender as TreeViewItem;
        StackPanel MyStackPanel = MyTreeViewItem.Header as StackPanel;
        Label MyLabel = MyStackPanel.Children[1] as Label;
        MyLabel.Foreground = Brushes.White;         
    }
