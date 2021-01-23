    List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
    
    int cellIndex = 0;
    
    foreach (DataGridViewRow row in dgResult1.Rows)
    {
        string regValue = row.Cells[cellIndex].Value.ToString();
        if(...)
        {
            rowsToRemove.Add(row);
        }
    }
    
    rowsToRemove.ForEach(r=>{
       dgResult1.Rows.Remove(r);
    });
