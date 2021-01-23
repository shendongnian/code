    private void btnAddTitle_Click(object sender, RoutedEventArgs e)
    {
        CurrentSortItem++;
        SortItems.Add(CurrentSortItem);
        GroupBox gb = new GroupBox();
        StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
        ....
        gb.Content = sp;
       
        spStandard.Children.Add(gb);
    }
