	private void AddColumns()
	{
		dataGridView1.AutoGenerateColumns = true;
	
		var ds = (from r in restaurants
				  from c in r.Complaints
				  select new {Id = r.Id, Address =c.Address, Age = c.Age, Name = c.Name, Date = c.ComplaintDate}
				 ).ToList();
		dataGridView1.DataSource = ds;
	}
