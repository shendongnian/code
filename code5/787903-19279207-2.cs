    _msSqlConn.Open();
    using (SqlDataAdapter da = new SqlDataAdapter(query, _msSqlConn))
    {
        DataTable dt = new DataTable();
        da.FillSchema(dt, SchemaType.Mapped); //Or may be SchemaType.Source
        return dt;
    }
