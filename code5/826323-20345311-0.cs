    static DataSet ds_input = new DataSet();
    static DataSet ds_output = new DataSet();
    private static void InitializeMyDataSet()
    {
        ds_output.Tables.Add(new DataTable() );
        ds_output.Tables[0].Columns.Add("column_1", typeof(string));
        ds_output.Tables[0].Columns.Add("column_2", typeof(string));
        ds_output.Tables[0].Columns.Add("column_4", typeof(string));
        ds_output.Tables[0].Columns.Add("column_3", typeof(string));
    }
