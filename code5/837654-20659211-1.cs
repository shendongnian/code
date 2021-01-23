         int index = 0;
         public void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
         {
            var row = (DataRowView)e.Row.Item;
            //If you want the content of a specific column of the current row
            //var content = row.Row[0].ToString(); 
            if (index == 15)
            {
                e.Row.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                e.Row.Foreground = new SolidColorBrush(Colors.Black);
            }
            index ++ ; //don't forget to increase the index
         }
