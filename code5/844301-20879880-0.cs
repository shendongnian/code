    for (int i = dgvBG.Columns.Count - 1; i >= 0; i--)
    {
        var col = dgvBG.Columns[i];
        if (col.HeaderText == "Edit" || col.HeaderText == "Delete" )
        {
            dgvBG.Columns.Remove(col);
            // col.Visible = false;
        }
    }
