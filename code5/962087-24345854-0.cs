    string _strCheckBoxName = "CH1";
    CheckBox DeleteCheckBox= new CheckBox();
    DeleteCheckBox.Name = strCheckBoxName ;
    DeleteCheckBox.Checked+=(s,e)=>CheckBox_Change(s,e);
    DeleteCheckBox.Unchecked+=(s,e)=>CheckBox_Change(s,e);
    DeleteCheckBox.Checked = true;
    
    private void CheckBox_Change(object sender, RoutedEventArgs e)
    {
      if ((sender as CheckBox).Name=strCheckBoxName && (bool)(sender as CheckBox).IsChecked)
      {
        // To Do Code
      }
    }
