    var spaces = new string(' ', 5);
    var start = dgv.SelectedRows[0].Index;
    List<int> rowsToDelete = new List<int> { start };
    
    for (int i = start; i < dgv.Rows.Count; i++)
    {
        // Uncommitted new rows cannot be removed programatically
        if (dgv.Rows[i].IsNewRow == false
            && dgv.Rows[i].Cells[0].Value.ToString().StartsWith(spaces))
        {
            rowsToDelete.Add(i);
        }
        else
        {
            break;
        }
    }
    
    rowsToDelete.Reverse();
    
    foreach (var rowIndex in rowsToDelete)
    {
        dgv.Rows.RemoveAt(rowIndex);
    }
