	string sql = "INSERT INTO Std_Subjects (subject_id, std_reg_id) VALUES (@SubjectID, @RegID)";
	for (int i = 0; i < listViewSubject.Items.Count; i+=2)
	{
		using (var conn = new SqlConnection(ConnectionString))
		using (var command = new SqlCommand(sql, connection))
		{
			conn.Open();
			command.Parameters.Add("@RegID", SqlDbType.Int).Value = this.reg_id;
			command.Parameters.Add(SubjectID, SqlDbType.Int).Value = listViewSubject[i].Text;
			command.ExecuteNonQuery();
		}
	}
