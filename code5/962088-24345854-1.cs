    string _strCheckBoxName = "CH1";
    CheckBox DeleteCheckBox= new CheckBox();
    DeleteCheckBox.Name = _strCheckBoxName ;
    DeleteCheckBox.Checked+=(s,e)=>CheckBox_Change(s,e);
    DeleteCheckBox.Unchecked+=(s,e)=>CheckBox_Change(s,e);
    DeleteCheckBox.IsChecked = true;
    
    private void CheckBox_Change(object sender, RoutedEventArgs e)
    {
      if ((sender as CheckBox).Name=_strCheckBoxName && (bool)(sender as CheckBox).IsChecked)
      {
        // To Do Code
      }
    }
