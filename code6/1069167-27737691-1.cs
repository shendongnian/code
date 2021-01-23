    public DataTable addPlanDetailDataRow()
    {
        DataTable dt = new DataTable();
    
        dt.Columns.Add("Activity");
        dt.Columns.Add("Duration");
        dt.Columns.Add("status");
        dt.Columns.Add("Time_Start");
        dt.Columns.Add("Plan_ID");
        if (ViewState["Datatable"] != null)
        {
        	dt = (DataTable)ViewState["Datatable"];
        }
        ViewState["Datatable"] = dt;
        DataRow dr = dt.NewRow();
    
        DataRow newRow = dt.NewRow();
    
        dt.Rows.Add(newRow);
    
        return dt;
    }
