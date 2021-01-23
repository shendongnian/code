        var cellInfos = dataGrid1.SelectedCells;
        List<string> list1 = new List<string>();
        foreach (DataGridCellInfo cellInfo in cellInfos)
        {
            if (cellInfo.IsValid)
            {
                //GetCellContent returns FrameworkElement
                var content= cellInfo.Column.GetCellContent(cellInfo.Item); 
                
                //Need to add the extra lines of code below to get desired output
                DataRowView row = (DataRowView)content.DataContext;//get the datacontext from FrameworkElement and typecast to DataRowView
                object[] obj = row.Row.ItemArray;//ItemArray returns an object array with single element
                list1.Add(obj[0].ToString());//store the obj array in a list or Arraylist for later use
            }
        }
