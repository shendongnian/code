    vat sql = string.Format("select * from tablename where id in ({0})", string.Join(",", ids.Select((v,i)=>":id"+i)));
    using(OracleCommand cmd = new OracleCommand(sql, dbc)) {
        int pos = 0;
        foreach (var id in Ids) {
            cmd.Parameters.Add("id"+pos, OracleDbType.Int64, 12, id , ParameterDirection.Input);
            pos++;
        }
        using(OracleDataReader rdr = cmd.ExecuteReader()) {
            ...
        }
    }
