    private void ListPicker_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    ListPickerItem item = lp_sound.SelectedItem as ListPickerItem;
    
    if(item!=null)
       bleep.Source = new Uri(Convert.ToString(item.Tag), UriKind.Relative);
    }
    
