    using (SqlDataAdapter da = new SqlDataAdapter(_msSqlConn, query))
    {
        DataTable dt = new DataTable();
        _msSqlConn.Open();
        da.FillSchema(dt, SchemaType.Mapped); //Or may be SchemaType.Source
    
        return dt;
    }
