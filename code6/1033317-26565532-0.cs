    if (dtgFunc.Rows[e.RowIndex]
       .Cells
       .Cast<DataGridViewCell>()
       .FirstOrDefault(x => x.Value.Equals("seller")) != null)
    {
       rdbSeller.Checked = true;
       rdbManager.Checked = false;
    }
    else
    {
       rdbManager.Checked = true;
       rdbSeller.Checked = false;
    }
