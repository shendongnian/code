        using(SqlCommand cmd=new SqlCommand("INSERT INTO Mem_Basic(Mem_Na,Mem_Occ) output INSERTED.ID VALUES(@na,@occ)",con))
        {
            cmd.Parameters.AddWithValue("@na", Mem_NA);
            cmd.Parameters.AddWithValue("@occ", Mem_Occ);
            con.Open();
            int modified =(int)cmd.ExecuteScalar();
            if (con.State == System.Data.ConnectionState.Open) 
                con.Close();
            return modified;
        }
    }
