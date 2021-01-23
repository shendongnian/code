      protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime selectedDate = CalendarMain.SelectedDate;
        string SportType = ddlSportType.SelectedItem.ToString();
        string distance = ddlDistance.SelectedItem.ToString();
        plan wp = new plan();
        wp.Time_Start = selectedDate;
        wp.Duration = distance;
        wp.Activity = SportType;
        
    	DataTable dt = new DataTable();
    
        dt.Columns.Add("Activity");
        dt.Columns.Add("Duration");
        dt.Columns.Add("status");
        dt.Columns.Add("Time_Start");
        dt.Columns.Add("Plan_ID");
    
    
        DataTable dt1 = wp.addPlanDetailDataRow(dt);
    
        gvActivityList.DataSource = dt;
        gvActivityList.DataBind();
    }
    public DataTable addPlanDetailDataRow(DataTable dt)
    {
        
         if (ViewState["Datatable"] != null)
        {
            dt = (DataTable)ViewState["Datatable"];
        }
        ViewState["Datatable"] = dt;
        DataRow dr = dt.NewRow();
        dr["Activity"]="value1";
        dr["Duration"]="value2";
        dr["status"]="value3";
        dr["Time_Start"]="value4";
        dr["Plan_ID"]="value5";
        
    
        DataRow newRow = dt.NewRow();
    
        dt.Rows.Add(newRow);
    
        return dt;
    }
