            clearTable();
            _oDataTable.Columns.Add("Name", typeof(string)); //no error here
            _oDataTable.Columns.Add("Value", typeof(string));
            _oDataTable.Columns.Add("Font", typeof(string));
            _oDataTable.Columns.Add("DateStamp", typeof(string));
            _oDataTable.Columns.Add("Comment", typeof(string));
            foreach (DataGridViewRow row in _grid.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                _oDataTable.Rows.Add(cellValues.ToArray());
            }
