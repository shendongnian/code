    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listBox = (ListBox)sender;
        var data = (Data)listBox.DataContext;
        System.Diagnostics.Debug.WriteLine(data.Title);
    }
