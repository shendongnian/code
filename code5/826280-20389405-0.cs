            string SqlString = "SELECT Top 1 Test3, Test4 from Table2 WHERE Test1 = @ID Order by Test4 ASC, Test3 ASC";
        using (objCon = new OleDbConnection(ConnectString))
        {
            using (objCmd = new OleDbCommand(SqlString, objCon))
            {
                objCmd.Parameters.AddWithValue("@ID", userID);
                objCon.Open();
                OleDbDataReader reader = objCmd.ExecuteReader();
                if (reader.Read())
                {
                    Label1.Text = reader["Test3"].ToString();
                    Label2.Text = reader["Test4"].ToString(); 
                    
                }
                reader.Close();
            }
        }
        objCon.Close();
    }
    
