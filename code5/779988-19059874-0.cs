	private void AddColumns()
	{
		DataGridViewTextBoxColumn ageColumn =
			new DataGridViewTextBoxColumn();
		ageColumn.Name = "Age";
		ageColumn.DataPropertyName = "Age";
		ageColumn.ReadOnly = true;
		DataGridViewTextBoxColumn nameColumn =
			new DataGridViewTextBoxColumn();
		nameColumn.Name = "Name";
		nameColumn.DataPropertyName = "Name";
		nameColumn.ReadOnly = true;
		DataGridViewTextBoxColumn addressColumn =
			new DataGridViewTextBoxColumn();
		addressColumn.Name = "Address";
		addressColumn.DataPropertyName = "Address";
		addressColumn.ReadOnly = true;
		dataGridView1.Columns.Add(ageColumn);
		dataGridView1.Columns.Add(nameColumn);
		dataGridView1.Columns.Add(addressColumn);
		dataGridView1.DataSource = restaurants;
	}
