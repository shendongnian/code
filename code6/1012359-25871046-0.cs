    DataTable dt = new DataTable();
    dt.Columns.Add("ID", typeof (string));
    dt.Columns.Add("Name", typeof (string));
    //populate your Datatable
    SqlParameter param = new SqlParameter("@userdefinedtabletypeparameter", SqlDbType.Structured)
    {
        TypeName = "dbo.userdefinedtabletype",
        Value = dt
    };
    sqlComm.Parameters.Add(param);
