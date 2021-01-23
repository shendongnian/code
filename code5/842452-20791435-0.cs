	void Main()
	{
		var dataGridView = new DataGridView();
		dataGridView.Columns.Add(new DataGridViewCheckBoxColumn());
		dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
		dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
		
		dataGridView.Columns[0].ReadOnly = true;
		dataGridView.Columns[1].ReadOnly = true;
		dataGridView.Columns[2].ReadOnly = true;
		
		dataGridView.CellClick += this.DataGridView_CellClick;
		
		dataGridView.Dump();
	}
	
	void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex < 0) return;
		
		var dataGridView = (DataGridView) sender;
		var cell = dataGridView[0, e.RowIndex];
		
		if (cell.Value == null) cell.Value = false;
		cell.Value = !(bool)cell.Value;
	}
