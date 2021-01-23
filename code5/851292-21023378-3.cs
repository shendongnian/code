    string strSql = "UPDATE Responses SET [OCR Title] = ?, DeadlineDate = ? " + 
                    "where OCR = ?";
    
    using (OleDbConnection newConn = new OleDbConnection(strProvider))
    {
         using (OleDbCommand dbCmd = new OleDbCommand(strSql, newConn))
         {
             dbCmd.CommandType = CommandType.Text;
             dbCmd.Parameters.AddWithValue("@p1", textBox5.Text);
             dbCmd.Parameters.AddWithValue("@p2", Convert.ToDateTime(textBox7.Text));
             dbCmd.Parameters.AddWithValue("@p3", textBox6.Text);
             newConn.Open();
             dbCmd.ExecuteNonQuery();
         }
    }
