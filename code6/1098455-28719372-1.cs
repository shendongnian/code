    DataGridViewTextBoxColumn normalColumn = new DataGridViewTextBoxColumn();
    DGV_Points.Columns.Insert(yourColumnIndex, normalColumn);
    DGV_Points.Rows.Add(11);  // we need at least one row where we can insert a cell
    DataGridViewComboBoxCell aCell = new DataGridViewComboBoxCell();
    DGV_Points.Rows[someRowIndex].Cells[yourColumnIndex] = aCell;
