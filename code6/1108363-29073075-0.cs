    this.BeginInvoke(new Action(() =>
    {
    	if (e.ColumnIndex == 2 && e.RowIndex >= 0)
    	{
    		string s = Convert.ToString(_dgvCoarseAggegateTest[e.ColumnIndex, e.RowIndex].Value);
    		string s1 = Convert.ToString(_dgvCoarseAggegateTest[e.ColumnIndex, 0].Value);
    		DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
    
    		string _SizeName = _cGetParrent._mGetParentCellValue(ref _dgvCoarseAggegateTest, e.RowIndex, 1);
    		_mFillSieveSizeGridCombo(_mGetMetalSizeID(_SizeName), ref c); // Here My Combo Will GetValues from SQL and it Returning Value
    		
    		this.SetCell(_dgvCoarseAggegateTest, e.ColumnIndex, e.RowIndex, c, s, s1);
    	}
    }));
    
    
    private void SetCell(DataGridView dgv, int columnIndex, int rowIndex, DataGridViewCell cell, string value, string firstColumnValue)
    {
    	if (this.InvokeRequired)
    	{
    		this.Invoke(new Action<DataGridView, int, int, DataGridViewCell, string, string>(SetCell), dgv, columnIndex, rowIndex, cell, value, firstColumnValue);
    		return;
    	}
    
    	dgv[columnIndex, rowIndex] = cell;
    	dgv[columnIndex, rowIndex].Value = value;
    	dgv[columnIndex, 0].Value = firstColumnValue;
    }
