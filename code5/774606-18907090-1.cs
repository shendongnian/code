    List<SqlParameter> parameters = new List<SqlParameter>();
    
    if (cond1) {
        conds.Add("name=@name");
        parameters.Add(new SqlParameter("@name") { Value = text1.Text; });
    }
    // etc.
    
    // later..
    cmd.Parameters.AddRange(parameters);
