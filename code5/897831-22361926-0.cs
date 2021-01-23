    ...
    SqlParameter parameter = new SqlParameter("@RegistrationNo", SqlDbType.VarChar);
    parameter.IsNullable = false;    
    parameter.Size = 20;
    parameter.Value = "1002";
    sqlCom.Parameters.Add(parameter);
    ...
