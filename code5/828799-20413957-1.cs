    string accessQuery = "INSERT INTO [table] (ProjectId, ProjectName) VALUES (@ProjectId, @ProjectName)";
    OleDbCommand cmd = new OleDbCommand(accessQuery, con);    
    con.Open();
    for (int i = 0; i < list.Count; i++)
    {
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProjectId", list[i].ProjectId);
        cmd.Parameters.AddWithValue("@ProjectName", list[i].ProjectName);
        cmd.ExecuteNonQuery();
    }
