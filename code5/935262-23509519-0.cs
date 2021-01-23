    string strSQL = "Select DueDate from tbl_AssignmentUpload1 where AssignmentTitle like '" + AssignmentTitle + "'";
    (SqlCommand myCommand = new SqlCommand(strSQL, cnn)) // Cnn is your sql connection
    {     
      using (SqlDataReader reader = myCommand.ExecuteReader())
      {
        while (reader.Read())
        {
         DateTime today1 = Convert.ToDateTime(reader["DueDate "].ToString());
        }
      }
    }
