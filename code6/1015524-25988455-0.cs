    private void themelistPicker1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ListPickerItem lpi = (sender as ListPicker).SelectedItem as ListPickerItem;
                themename = lpi.Content.ToString();
                if (themename == "Dark")
                {
                  ThemeManager.ToDarkTheme();
                }
                else 
                {
                  ThemeManager.ToLightTheme();
                }
            }
