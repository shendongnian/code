    string strSql = "INSERT INTO Responses (OCR, DeadlineDate, [OCR Title]) VALUES (?, ?, ?)";
    
    using (OleDbConnection newConn = new OleDbConnection(strProvider))
    {
      using (OleDbCommand dbCmd = new OleDbCommand(strSql, newConn))
      {
        dbCmd.CommandType = CommandType.Text;
        dbCmd.Parameters.AddWithValue("OCR", textBox5.Text);
        dbCmd.Parameters.AddWithValue("DeadlineDate", textBox7.Text);
        dbCmd.Parameters.AddWithValue("[OCR Title]", textBox6.Text);
        newConn .Open();
        dbCmd.ExecuteNonQuery();
      }
    }
