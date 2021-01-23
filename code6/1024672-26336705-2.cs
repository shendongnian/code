    public bool _MFillGridView(string pQuery, ref DataGridView _pDgv, int columnIndex, int width)
    {
        using (var dt = new DataTable())
        {
            // ... Code to retrieve data from Database ...
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                var column = dt.Columns[i];
                if (column.DataType == typeof (DateTime))
                    _pDgv.Columns[column.ColumnName].DefaultCellStyle = new DataGridViewCellStyle {Format = _pDateFormat};
                else if (column.DataType == typeof (decimal))
                    _pDgv.Columns[column.ColumnName].DefaultCellStyle = new DataGridViewCellStyle {Format = _CObjectsofClasses._obj_CNumbricFunction._MFormatNo("0")};
                // Do your DataGridView formatting here
                if (_pDgv.Columns[column.ColumnName].Index.Equals(columnIndex)) // Check your Column index on the control
                {
                    _pDgv.Columns[column.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    _pDgv.Columns[column.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    _pDgv.Columns[column.ColumnName].Width = width;
                }
            }
        }
        return true;
    }
