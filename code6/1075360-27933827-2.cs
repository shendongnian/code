    using(SqlConnection con = new SqlConnection(.......)
    {
        con.Open();
        DataTable schema = con.GetSchema("Columns", new string[] {null, null, "items"});
        foreach(DataRow row in schema.Rows)
            Console.WriteLine("TABLE:" + row.Field<string>("TABLE_NAME") + 
                              " COLUMN:" + row.Field<string>("COLUMN_NAME"));
    }
