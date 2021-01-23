    var cellInfos = dataGrid1.SelectedCells;
    
    var list1 = new List<string>();
    foreach (DataGridCellInfo cellInfo in cellInfos)
    {
        if (cellInfo.IsValid)
        {
            //GetCellContent returns FrameworkElement
            var content= cellInfo.Column.GetCellContent(cellInfo.Item); 
                
            //Need to add the extra lines of code below to get desired output
            //get the datacontext from FrameworkElement and typecast to DataRowView
            var row = (DataRowView)content.DataContext;
            
            //ItemArray returns an object array with single element
            object[] obj = row.Row.ItemArray;
            //store the obj array in a list or Arraylist for later use
            list1.Add(obj[0].ToString());
        }
    }
