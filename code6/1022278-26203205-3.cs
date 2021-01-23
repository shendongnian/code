      string conStr = "Server=localhost;Database=master;Trusted_Connection=True;";
            con = new SqlConnection(conStr);
            con.Open();
      using (con)
            {
                SqlCommand insertCommand = new SqlCommand("InsertQuestionList", con);
                SqlParameter tvpParam = insertCommand.Parameters.AddWithValue(
                    "@QuestionList", myDataTable);
                insertCommand.CommandType = CommandType.StoredProcedure;
    
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "dbo.QuestionList";
                tvpParam.Value = myDataTable;
                insertCommand.ExecuteNonQuery();
            }
            
            con.Close();
