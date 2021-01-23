    private async void OnDoubleClick(object sender, 
    Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)    
    {
    
    }
    private void OnFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
    ListviewItem lv = (ListViewItem)e.OriginalSource;
    string str = lv.SelectedItem.tostring();
    }
