    string strSql = "UPDATE Responses SET [OCR Title] = ?
                     where OCR = ?"; 
    using (OleDbConnection newConn = new OleDbConnection(strProvider))
    {
         using (OleDbCommand dbCmd = new OleDbCommand(strSql, newConn))
         {
              dbCmd.CommandType = CommandType.Text;
              dbCmd.Parameters.AddWithValue("@OCRTitle", textBox6.Text);
              dbCmd.Parameters.AddWithValue("@OCR", textBox5.Text);
              newConn.Open();
              dbCmd.ExecuteNonQuery();
         }
    }
