    string sql = " SELECT * FROM dbo.Account WHERE 1=1";
    var pars = new List<SqlParameter>();
    if (!string.IsNullOrWhiteSpace(txtAccountNumber.Text))
    {
        parameterizedQuery += " AND AccountNumber = @AccountNumber";
        var par = new SqlParameter("@AccountNumber", SqlDbType.NVarChar, 10);
        par.Value = txtAccountNumber.Text;
        pars.Add(par);
    }
    //5 more instances of similar query building for other fields
    SqlCommand cmd = new SqlCommand(sql, sqlconn);
    if (pars.Length > 0) cmd.Parameters.AddRange(pars.ToArray());
