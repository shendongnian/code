    List<string>chzone=new List<string>();//Declare it as globally,
    //Note: if DataGrid is Binded as ,Datagrid.Itemsource=dt.defaultview;
    //If datagrid contain the Checkbox, get the checked item row and add it into list
    private void DataGridcheckbox_Checked(object sender, RoutedEventArgs e)
            {
               
                var checker = sender as CheckBox;           
                if (checker.IsChecked == true)
                {
                    var item = checker.DataContext as DataRowView;
                    object[] obj = item.Row.ItemArray;//getting entire row
                    chzone.Add(obj[0].ToString());//getting row of first column value
                }
                else //This is for Unchecked Scenario
                {
                    var item = checker.DataContext as DataRowView;
                    object[] obj = item.Row.ItemArray;
                    bool res = chzone.Contains(obj[0].ToString());
                    if (res == true)
                    {
                        chzone.Remove(obj[0].ToString());//this is used to remove item in list
                    }
                }
    
            }
