     private void ThemeListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                //get the name of the current item in the listpicker?
              string currentItemName =string.Empty;
              Theme theme= (sender as ListPicker).SelectedItem as Theme;
              if(theme!=null)
               {
                 currentItemName  = item.Name;
               }
            }
            
