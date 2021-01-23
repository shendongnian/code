    using (OleDbConnection con = new OleDbConnection(constr))
        using (OleDbCommand com = new OleDbCommand("SELECT COUNT(*) FROM StudentList WHERE [FName] = @FName AND [LName] = @LName", con))
        {
            // Add your @Fname and @LName parameters here
            com.Parameters.AddWithValue("@FName", firstName);
            com.Parameters.AddWithValue("@LName", lastName);
            con.Open();
            using (OleDbDataReader myReader = com.ExecuteReader())
            {
                myReader.Read();
                int count = myReader.GetInt32(0);
                // return count > 0 or whatever to indicate that it exists
            }
        }
