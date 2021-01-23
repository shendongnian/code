    if (dgv.CurrentCell == null) return;
    var spaces = new string(' ', 5);
    var start = dgv.CurrentCell.RowIndex;
    if (start == dgv.Rows.Count) return;
    List<int> rowsToDelete = new List<int> { start };
    start++;
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
    rowsToDelete.Reverse(); // List.Reverse() reverses the list in place and returns void
    foreach (var rowIndex in rowsToDelete)
    {
        dgv.Rows.RemoveAt(rowIndex);
    }
