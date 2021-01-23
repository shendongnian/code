    private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex != 2) // enum value column
			return;
        
		var grid = (DataGridView)sender;
        MyEnum val = (MyEnum)grid[e.ColumnIndex, e.RowIndex].Value;
		switch (val)
		{
			case MyEnum.Val1: e.Value = "Translation1"; break;
			case MyEnum.Val2: e.Value = "Translation2"; break;
		}
		
		e.FormattingApplied = true;
    }
