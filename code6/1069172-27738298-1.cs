    public plan()
	{
		//
		// TODO: Add constructor logic here
		//
       
	}
    public DataTable dt;
    public void InitDataTable()
    {
        dt = new DataTable();
        dt.Columns.Add("Activity");
        dt.Columns.Add("Duration");
        dt.Columns.Add("status");
        dt.Columns.Add("Time_Start");
        dt.Columns.Add("Plan_ID");
    }
    public DateTime Time_Start;
    public string Duration;
    public string Activity;
    
    public DataTable addPlanDetailDataRow()
    {
        DataRow newRow = dt.NewRow();
        newRow["Activity"] = this.Activity;
        newRow["Duration"] = this.Duration;
        newRow["status"] = "s1";
        newRow["Time_Start"] = this.Time_Start;
        newRow["Plan_ID"] = "p1";
        dt.Rows.Add(newRow);
        return dt;
    }
