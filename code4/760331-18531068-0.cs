	var form = new Form();
	
	var dgv = new DataGridView { Dock = DockStyle.Fill };
	
	var table = new TableLayoutPanel 
	{ 
		Dock = DockStyle.Fill,
		ColumnCount = 1,
		RowCount = 2
	};
	
    table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
    table.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
    table.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
	table.Controls.Add(dgv, 0, 1);
	form.Controls.Add(table);
	form.ShowDialog();
