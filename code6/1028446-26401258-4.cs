	private void report()
	{
        dataGridView4.AutoResizeColumns();
        dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        string connectionString = ConfigurationManager.ConnectionStrings["smssms"].ConnectionString;
		string sql = @"SELECT	t.admission_number,
								t.student_name,
								t.student_class
						FROM	tenthclass_marks AS t
						UNION ALL
						SELECT	e.admission_number,
								e.student_name,
								e.student_class
						FROM	eighth_to_ninth_marks AS e;";
		
		DataTable dt = new DataTable();		
		using (var adapter = new SqlDataAdapter(sql, connectionString))
		{
			adapter.Fill(dt);
		}
		dataGridView4.DataSource = dt;
	}
