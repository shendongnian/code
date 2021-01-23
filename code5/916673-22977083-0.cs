    private void listname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             (((sender.Content as StackPanel).Children[0] as StackPanel).Children[0] as Image).Source 
             = //Whatever the new source is;
    
             listSideOptions.SelectedIndex = -1;
        }
