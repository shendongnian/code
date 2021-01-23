    using (var cn = new SqlCeConnection("connection string here"))
    using (var cmd = new SqlCeCommand("insert into addNew (no,session,name) values (@no,@session,@name)", cn))
    {
        //guessing at column lengths:
        cmd.Parameters.Add("@no", SqlDbType.Int).Value = int.Parse(admNo.Text);
        cmd.Parameters.Add("@session", SqlDbType.NVarChar, 100).Value = session.Text;
        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 60).Value = name.Text;
    
        cn.Open();
        cmd.ExecuteNonQuery();
    }
