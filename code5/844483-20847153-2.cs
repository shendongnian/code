    string stmt = "INSERT INTO dbo.Test(id, name) VALUES(@ID, @Name)";
    SqlCommand cmd = new SqlCommand(stmt, _connection);
    cmd.Parameters.Add("@ID", SqlDbType.Int);
    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100);
    
    for (int i = 0; i < 10000; i++)
    {
        cmd.Parameters["@ID"].Value = i;
        cmd.Parameters["@Name"].Value = i.ToString();
    
        cmd.ExecuteNonQuery();
    }
