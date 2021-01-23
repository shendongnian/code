    using (IDbConnection db = new OracleConnection(connectionString)) {
        var p = new OracleDynamicParameters();
        p.Add("p_first_parameter", someParameter, OracleDbType.Varchar2, ParameterDirection.Input);
        p.Add("o_cursr", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
        p.Add("o_sqlerrm", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output, size: 200);
        p.Add("o_sqlcode", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Output, size: 200);
        dynamic csr = db.Query("myStoredProcedure", p, commandType: CommandType.StoredProcedure).ToList().First();
        string code = p.Get<OracleString>("o_sqlcode").ToString();
        if (code != "0") {
            string errm = p.Get<OracleString>("o_sqlerrm").ToString();
            throw new Exception($"{code} - {errm}");
        }
    }
