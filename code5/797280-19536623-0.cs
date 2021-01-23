    protected void BindActivities()
    {
    	foreach (string controlName in NoOfControls)
    	{
    		TimesheetUserControl  userControl = Timesheet.FindControl(controlName) as TimesheetUserControl;
    		if(userControl == null) return;
    		DropDownList dropActivities = userControl.FindControl("DropDownActivities") as DropDownList;
    		if(dropActivities == null) return;
    		DbConnection.Open();
    		OleDbCommand cmd1 = new OleDbCommand("select designation from emp_master where username = '" + username + "'", DbConnection);
    		OleDbDataAdapter da = new OleDbDataAdapter(Deptcmd);
    		DataSet ds = new DataSet();
    		da.Fill(ds);
    		// DbConnection.Close();
    		dropActivities.DataSource = ds;
    		dropActivities.DataTextField = "ActivityName";
    		dropActivities.DataBind();
    		dropActivities.Items.Insert(0, new ListItem("--Select--", "0"));
    	}
    }
