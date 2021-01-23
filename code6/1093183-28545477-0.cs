    var spaces = new string(" ", 5);
    var start = dgv.SelectedRows[0].Index;
    List<int> rowsToDelete = new List<int> { start };
   
    for (int i = start; i < dgv.Rows.Count; i++)
    {   
        // Uncommitted new rows cannot be removed programatically
        if (dgv.Row[i],IsNewRow == false 
         && dgv.Row[i].Cells[0].Value.StartsWith(spaces))
        { 
             rowsToDelete.Add(i);
        }
        else
        {
             break;
        }
    }    
    foreach (var rowIndex in rowsToDelete.Reverse())
    {
         dgv.Rows.RemoveAt(rowIndex);
    }
