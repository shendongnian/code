TableLayoutPanel tablePanel = new TableLayoutPanel(); //Initialize and do any other construction
tablePanel.AddColumn(null, "Column1");
tablePanel.AddRow(new RowStyle() { SizeType = SizeType.Absolute, Height = 50 }, "RowData1", "RowData2", "RowData3");
	public static int AddRow(this TableLayoutPanel table, RowStyle rowStyle = null, params string[] rowData)
	{
		List<Label> labels = new List<Label>();
		rowData.ToList().ForEach(p => labels.Add(new Label() { Text = p }));
		return table.AddRow(rowStyle, labels.ToArray());
	}
	public static int AddRow(this TableLayoutPanel table, RowStyle rowStyle = null, params Control[] rowData)
	{
		table.RowCount = table.RowCount + 1;
		if (rowStyle == null)
			rowStyle = new RowStyle(SizeType.AutoSize);
		table.RowStyles.Add(rowStyle);
		for (int i = 0; i < rowData.Length; i++)
		{
			if (i > table.ColumnCount - 1)
				break;
			table.Controls.Add(rowData[i], i, table.RowCount - 1);
		}
		return table.RowCount - 1;
	}
	public static int AddColumn(this TableLayoutPanel table, ColumnStyle columnStyle = null, params string[] columnData)
	{
		List<Label> labels = new List<Label>();
		columnData.ToList().ForEach(p => labels.Add(new Label() { Text = p }));
		return table.AddColumn(columnStyle, labels.ToArray());
	}
	public static int AddColumn(this TableLayoutPanel table, ColumnStyle columnStyle = null, params Control[] columnData)
	{
		table.ColumnCount = table.ColumnCount + 1;
		if (columnStyle == null)
			columnStyle = new ColumnStyle(SizeType.AutoSize);
		table.ColumnStyles.Add(columnStyle);
		for (int i = 0; i < columnData.Length; i++)
		{
			if (i > table.RowCount - 1)
				break;
			table.Controls.Add(columnData[i], table.ColumnCount - 1, i);
		}
		return table.ColumnCount - 1;
	}
