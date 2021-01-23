    private void ThemeListPicker_SelectionChanged(object sender,
                                              SelectionChangedEventArgs e)
    {
       if(ThemeListPicker.SelectedIndex==-1)
               return;
           var theme = (sender as ListPicker).SelectedItem;
           if (index == 0)
           {
              Settings.LightTheme.Value = true;
              MessageBox.Show("light");
           }
           else
           {
               Settings.LightTheme.Value = false;
               MessageBox.Show("dark");
           } 
           ThemeListPicker.SelectedIndex=-1                              
    } 
