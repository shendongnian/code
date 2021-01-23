      public int CreateNewMember(string Mem_NA, string Mem_Occ )
         {
            using (SqlConnection con=new SqlConnection(Config.ConnectionString))
         {
		  int newID;
		  var cmd = "INSERT INTO Mem_Basic(Mem_Na,Mem_Occ) VALUES(@na,@occ);SELECT CAST(scope_identity() AS int)";
            using(SqlCommand cmd=new SqlCommand(cmd, con))
            {
                cmd.Parameters.AddWithValue("@na", Mem_NA);
                cmd.Parameters.AddWithValue("@occ", Mem_Occ);
                 con.Open();
                newID = (int)insertCommand.ExecuteScalar();
                if (con.State == System.Data.ConnectionState.Open) con.Close();
                return newID;
            }
        }
    }
