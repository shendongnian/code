    SqlCommand cmd = new SqlCommand();
    cmd.Connection = sqlconn;
    command.CommandType = CommandType.Text;
    string parameterizedQuery = " SELECT * FROM dbo.Account WHERE ";
    if (!string.IsNullOrEmpty(txtAccountNumber.Text.Trim()))
    {
        parameterizedQuery += " AccountNumber = @AccountNumber";
        cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNumber.Text.Trim());
    }
    ...
    cmd.CommandText = parameterizedQuery;
