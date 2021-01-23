    private void AddColumns()
	{
		dataGridView1.AutoGenerateColumns = false;
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
		DataGridViewTextBoxColumn dateColumn =
			new DataGridViewTextBoxColumn();
		addressColumn.Name = "Date";
		addressColumn.DataPropertyName = "Date";
		addressColumn.ReadOnly = true;
		dataGridView1.Columns.Add(ageColumn);
		dataGridView1.Columns.Add(nameColumn);
		dataGridView1.Columns.Add(addressColumn);
		dataGridView1.Columns.Add(dateColumn);
		
		var ds = (from r in restaurants
				  from c in r.Complaints
				  select new {Id = r.Id, Address =c.Address, Age = c.Age, Name = c.Name, Date = c.ComplaintDate}
				 ).ToList();
		dataGridView1.DataSource = ds;
	}
