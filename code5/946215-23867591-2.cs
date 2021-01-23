    try
    {
        SqlCommand command = new SqlCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = sc;
        command.CommandText = "InsertDars";
        SqlParameter param1 = new SqlParameter("@id", tbldrs.ID);
        SqlParameter param2 = new SqlParameter("@Name", tbldrs.Name);
        SqlParameter param3 = new SqlParameter("@Vahed", tbldrs.Vahed);
        /*NEW*/
        command.Parameters.Add(param1);
        command.Parameters.Add(param2);
        command.Parameters.Add(param3);
        command.ExecuteNonQuery();
    }
