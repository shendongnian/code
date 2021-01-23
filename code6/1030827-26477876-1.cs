    private string SelectedDepartmentText
    {
    	get
    	{
    		if(ViewState["SelectedDepartmentText"] != null)
                return ViewState["SelectedDepartmentText"].ToString();
            else
                return string.Empty;
    	}
    	set{ViewState["SelectedDepartmentText"] = value;}
    }
    
    public DataSet.employeesDataTable EmployeesTable
    {
         get
    	{
               if(!SelectedDepartmentText.Equals(lblDepartment.Text))
               {
                   // if the SelectedDepartmentText isn't the same as the lblDepartment.Text, go fetch it
                   DataSetTableAdapters.employeesTableAdapter TA = new DataSetTableAdapters.employeesTableAdapter();
                   ViewState["EmployeesTable"] =TA.GetDataByDepartment(lblDepartment.Text);
                   // save the lblDepartment.Text value to the viewstate for next time.
                   SelectedDepartmentText = lblDepartment.Text;
                   return ViewState["EmployeesTable"];
               }
               else
    	       {
                   // let's see if we have something already and return it
                   if(ViewState["EmployeesTable"] != null)
                       return (DataSet.employeesDataTable)ViewState["EmployeesTable"];
                   else
                    {
     
                    // if we don't, let's get it, this also handles an empty string for the                     
                    // lblDepartment.Text
    			DataSetTableAdapters.employeesTableAdapter TA = new DataSetTableAdapters.employeesTableAdapter();
                            // store it in the viewstate
    			ViewState["EmployeesTable"] =TA.GetDataByDepartment(lblDepartment.Text);
                            // and return whatever we got back
    			return (DataSet.employeesDataTable)ViewState["EmployeesTable"];
                    }
               }
               return null;
    	}
    	set{ ViewState["EmployeesTable"] = value;}
    }
