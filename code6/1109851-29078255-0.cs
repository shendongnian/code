    // Create the command and set its properties.
    SqlCommand command = new SqlCommand();
    command.Connection = connection;
    command.CommandText = "ProcedureName";
    command.CommandType = CommandType.StoredProcedure;
    // Add the input parameter and set its properties.
    SqlParameter parameter = new SqlParameter();
    parameter.ParameterName = "@email";
    parameter.SqlDbType = SqlDbType.NVarChar;
    parameter.Direction = ParameterDirection.Input;
    parameter.Value = textEmail.Text;
    // Add the parameter to the Parameters collection. command.Parameters.Add(parameter);
