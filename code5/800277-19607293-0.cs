    public DataTable myDatatable()
    {
       DataTable dt = HttpContext.Current.Cache["key"] as DataTable;
       if(dt == null)
       {
           dt = myDatatable();
           HttpContext.Current.Cache["key"] = dt;
       }
       return dt;
    }
