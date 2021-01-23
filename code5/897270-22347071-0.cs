    protected void gvDepartments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Empty the string variable
        myDeptResponseCount = "";
        // Iterate though the gridView to get Dept names and response count values
    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // the actual way to get your row index            
            int rowIndex = e.Row.RowIndex;
    
            //Label respCount = dept.FindControl("lblResponses"+ dID) as Label;
            Label lblResponses = (Label)e.Row.FindControl("lblResponses" + dID);
    
            deptName = e.Row.Cells[1].Text.ToString();
    
            // get the responseCount for each of the departments
            myDeptResponseCount = getDepartmentResponseCount.ResponseCount(deptName);
    
            //lblResponses.Text = myResponseCount;
            deptCount.Add(deptName);
        }
    
        //dID++;
        deptNameCount.Add(deptName);
    }
