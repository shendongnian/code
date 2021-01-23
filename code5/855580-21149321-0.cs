	public void loadGrid1()
	{
		con.Open();
		cmd = new SqlCommand(@"SELECT StudID, Stud_Lname, Stud_Fname FROM STUDENTS;",con);
		rdr = cmd.ExecuteReader();
		while (rdr.Read())
		{
			dataGridView2.Rows.Add(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString());
		}
		// check if dataGridView2 has more than 0 rows
		// and then select the first row by default
		if(dataGridView2.Rows.Count > 0)
		{
			dataGridView2.Rows[0].Selected = true
		}
		con.Close();
	}
