    DataTable table = new DataTable();
    using(var con = new SqlConnection("...."))
    using(var da = new SqlDataAdapetr("SELECT ... WHERE...", con))
    {
        da.Fill(table);
    }  
    // now you have the row(s)
