    // when we += multiple string we better use a StringBuilder
    StringBuilder updateSQL = new StringBuilder();
    // create our update statement 
    updateSQL.Append("UPDATE Projects SET "); // there is as space on purpose!
    
    if (CheckBox_ProjectResults.Checked)
    {
    	updateSQL.Append("DateCompleted=@DateCompleted,");
    	cmd.Parameters.AddWithValue("@DateCompleted", TxtActualEnd.Text);
    
    	updateSQL.Append("TrackerNumber=@TrackerNumber,");
    	cmd.Parameters.AddWithValue("@TrackerNumber", UpdatetxtTrackerNumber.Text);
    
    	updateSQL.Append("DocumentName=@DocumentName,");
    	cmd.Parameters.AddWithValue("@DocumentName", attachmentFileUpload.FileName);
    
    else 
    {
    	updateSQL.Append("DateAssigned=@StartDate,");
    	cmd.Parameters.AddWithValue("@StartDate", UpdatetxtStartDate.Text);
    
    	updateSQL.Append("DueDate=@DueDate,")
    	cmd.Parameters.AddWithValue("@DueDate", UpdatetxtEndDate.Text);
    
    	updateSQL.Append("SystemNumber=@SystemNumber,");
    	cmd.Parameters.AddWithValue("@SystemNumber", DropDownList2.SelectedItem.Text);
    }
    // this is always there so make it our last one
    updateSQL.Append("ProjectDescription=@ProjectDescription "); // notice no comma but a space!
    cmd.Parameters.AddWithValue("@ProjectDescription", UpdatetxtProjectDesc.Text);
    
    // no matter what Projectname is always there because it is the where!
    cmd.Parameters.AddWithValue("@ProjectName", DDL1.SelectedItem.Text);
    updateSQL.Append("WHERE ProjectName=@ProjectName");
    
    // dispose connection
    using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectsAndTasksTestConnectionString"].ConnectionString))
    {
        // call ToString on the String builder
        using(var cmd = new SqlCommand(updateSQL.ToString(), con))
        {
            int  updated = 0;
            try
            {
                con.Open();
                updated = cmd.ExecuteNonQuery();
                lblResults.Text = String.Format("{0} record(s) updated.", updated);
            }
            catch (SqlException sqlExc)
            {
                lblResults.Text = String.Format("Error updating. {0} - {1} - {2}"
                                   , sqlExc.Message
                                   , sqlExc.Number
                                   , sqlExc.LineNumber);
            }
        }
    }
