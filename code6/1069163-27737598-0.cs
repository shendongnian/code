    DataTable dt = new DataTable();
    private InitDataTable() //This method should be called once
    {
        dt.Columns.Add("Activity");
        dt.Columns.Add("Duration");
        dt.Columns.Add("status");
        dt.Columns.Add("Time_Start");
        dt.Columns.Add("Plan_ID");
    
    } 
    public DataTable addPlanDetailDataRow()
    {     
        DataRow newRow = dt.NewRow();    
        dt.Rows.Add(newRow);    
        return dt;
    }
