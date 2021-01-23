	cmd = new SqlCommand("Update NOTESMAKER set NOTESMAKER = @text1)",con);
	cmd.Parameters.Add(new SqlParameter("@text1", SqlDbType.NText)).Value = TextBox1.Text;
	int affectedRows = cmd.ExecuteNonQuery();
	
	if (affectedRows == 0)
	{
		cmd = new SqlCommand("Insert into NOTESMAKER(NOTESMAKER) Values(@text1)",con);
		cmd.Parameters.Add(new SqlParameter("@text1", SqlDbType.NText)).Value = TextBox1.Text;
		cmd.ExecuteNonQuery();
	}
