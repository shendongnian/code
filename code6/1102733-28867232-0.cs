     public void TryGridRefresh(string IdUniqueToFind, DataGrid MyDataGrid, string MyGridColumnToSearch)
        {  
            int IDToFind = Convert.ToInt32(IdUniqueToFind);
	// this if did not work for me..got errors	
            //if (IDToFind > -1) and (dataGrid_MonikerName.ItemsSource is DataView )
            //{
            foreach (DataRowView drv in (DataView)MyDataGrid.ItemsSource)
            {               
                if ((int)drv[MyGridColumnToSearch] == IDToFind)
                {
                    // This is the data row view record you want...
                    MyDataGrid.SelectedItem = drv;
                    MyDataGrid.ScrollIntoView(drv);
                    MyDataGrid.Focus();
                    break;
                }
            }
        }       
