        using(SqlCommand cmd=new SqlCommand("INSERT INTO Mem_Basic(Mem_Na,Mem_Occ)  VALUES(@na,@occ);SELECT SCOPE_IDENTITY();",con))
        {
            cmd.Parameters.AddWithValue("@na", Mem_NA);
            cmd.Parameters.AddWithValue("@occ", Mem_Occ);
            con.Open();
            int modified = cmd.ExecuteScalar();
            if (con.State == System.Data.ConnectionState.Open) con.Close();
                return modified;
        }
    }
