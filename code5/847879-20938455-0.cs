    using (SqlConnection con = new SqlConnection(AcessoBD.ConnectionString))
    {
        con.Open();
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandText = @"INSERT INTO si_usuario (senha, login) VALUES ('aaa', 'aaa');";
            cmd.ExecuteNonQuery();
    
        }
    }
