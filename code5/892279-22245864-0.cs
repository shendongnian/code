    // Create an instance of the LogicLayer
    LogicLayer mySurvey = new LogicLayer();
    DataLayer getResponseCount = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        gvDepartments.DataSource = mySurvey.SelectDepartment();
        gvDepartments.DataBind();
        gvDepartments.Visible = true;
    }
    protected void gvDepartments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Declare a counter variable
        int dID = 0;
        string responses;
        string deptName;
        //string responseR;
        // Iterate though the gridView to get Dept names and response count values
        foreach (GridViewRow dept in gvDepartments.Rows)
        {
            //Label respCount = (Label)dept.FindControl("lblResponse").Text
            // the actual way to get your row index
            int rowIndex = dept.RowIndex;
            Label respCount = (Label)gvDepartments.Rows[dID].FindControl("lblResponses");
            responses = respCount.Text.ToString();
            // dept.Cells[rowIndex].ToString();  Get the department name on the gridview
            **deptName = e.Row.Cells[1].Text.ToString();**
            // get the responseCount for each of the departments and Map to Labels
            responses = getResponseCount.ResponseCount(deptName);
            
            dID++;
        }
    }
