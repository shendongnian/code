    thisConnection.Open();
    SqlCommand command = new SqlCommand(commandtext, thisConnection);
    command.CommandText = "Insert into Table (Comments)values(@Comments)";
    SqlParameter param  = new SqlParameter();
    param.ParameterName = "@Comments";
    param.Value         = Comments;
    command.Parameters.Add(param);
    command.ExecuteNonQuery();
    thisConnection.Close();
