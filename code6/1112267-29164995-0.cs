    // Add column for names (people and shifts)
    DataGridViewColumn names = new DataGridViewTextBoxColumn();
    names.DataPropertyName = "Name";
    names.DefaultCellStyle.BackColor = System.Drawing.Color.Azure;
    names.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    names.SortMode = DataGridViewColumnSortMode.NotSortable;
    _rotaView.Columns.Add(names);
