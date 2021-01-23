    private DataTable BuildDataTable()
    {
       var dt = new DataTable();
        //ParamId   | Code   | Val   | date_time
        dt.Columns.Add("id", typeof(string));
        dt.Columns.Add("code", typeof(int));
        dt.Columns.Add("val", typeof(double));
        dt.Columns.Add("date_time", typeof(DateTime));
        return dt;
    }
