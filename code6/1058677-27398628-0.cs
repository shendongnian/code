    public DataTable MethodName(string Param)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Order", typeof(Int32));
        dt.Columns.Add("Driver", typeof(Int32));
        DataRow dr = dt.NewRow();
        dr["Order"] = AnotherMethod1(Param) ? 1 : 0;
        dr["Driver"] = AnotherMethod2(Param) ? 1 : 0;
        dt.Rows.Add(dr);           
        return dt;
}
