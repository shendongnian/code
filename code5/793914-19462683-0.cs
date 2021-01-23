    private async void OnDoubleClick(object sender, 
    Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)    
    {
    
    }
    private void OnFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
    ListviewItem lv = (ListViewItem)e.Originalsource;
    string str = lv.SelectedItem.tostring();
    }
