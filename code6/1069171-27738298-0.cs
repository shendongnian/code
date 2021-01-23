     protected void btn1_Click(object sender, EventArgs e)
     {
        DateTime selectedDate = DateTime.Now;
        string SportType = "Dummy SportType";
        string distance = "Dymmy distance";
        plan wp = new plan();
        wp.Time_Start = selectedDate;
        wp.Duration = distance;
        wp.Activity = SportType;
        DataTable dt;
        if (ViewState["Datatable"] != null) // 
        {
            wp.dt = (DataTable)ViewState["Datatable"];
        }
        else
        {
            wp.InitDataTable();
        }        
        dt = wp.addPlanDetailDataRow();
        ViewState["Datatable"] = dt;
        gvActivityList.DataSource = dt;
        gvActivityList.DataBind();
    }
