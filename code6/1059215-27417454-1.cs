     var SelectedList=new List<YourDataGridItemType>();
        for (int i = 0; i < MyDataGrid.Items.Count; i++)
                {
                    var item = MyDataGrid.Items[i];
                    var mycheckbox = MyDataGrid.Columns[1].GetCellContent(item) as CheckBox;
                    if ((bool)mycheckbox.IsChecked)
                    {                 
                        SelectedList.Add(YourDataGridItemsList[i]);
                    }
                }
