    private DataTable GetDataTableFromDataGridview(DataGridView _grid)
        {
          {
                var _oDataTable = new DataTable();
                object[] cellValues = new object[_grid.Columns.Count];
                foreach (DataGridViewRow row in _grid.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                       if (i ==0)
                       {
                        clearTable();
                        _oDataTable.Columns.Add("Name", typeof(string)); //error here
                        _oDataTable.Columns.Add("Value", typeof(string));
                        _oDataTable.Columns.Add("Font", typeof(string));
                        _oDataTable.Columns.Add("DateStamp", typeof(string));
                        _oDataTable.Columns.Add("Comment", typeof(string));
                       }
                        cellValues[i] = row.Cells[i].Value;
                    }
                    _oDataTable.Rows.Add(cellValues.ToArray());
                }
                return _oDataTable;
    
            }
    }
