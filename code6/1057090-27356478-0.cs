    private void SelectionChanged_Tab(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl)
        {
            ListView2.Focus();
            ListView1.SelectedIndex = -1;
            ListView2.SelectedIndex = -1;
        }
    
        if (ListView2.SelectedIndex == -1)
        {
            ListView1.Focus();
        }
    }
