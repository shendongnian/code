        var cellInfos = dataGrid1.SelectedCells;
        foreach (DataGridCellInfo cellInfo in cellInfos)
        {
            if (cellInfo.IsValid)
            {
                
                var content= cellInfo.Column.GetCellContent(cellInfo.Item); 
            }
        }
