    private void CycleTileCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(checkFlag!=0)
            {
            var cb = sender as CheckBox;
            if (cb.IsChecked.HasValue)
            {
                if (cb.IsChecked.Value == true)
                {
                    Settings.CheckBoxEnabled.Value = true;
                    //..code that calls another method which also shows a CustomMessageBox
                }
            }
          }
          else
          {checkFlag=1;}
        }
            
