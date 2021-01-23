    // define your query upfront - using a PARAMETER!
    string query = "SELECT SUM(Marks) FROM dbo.Marksheet WHERE StudentGUID = @StudentID;";
    // put the SqlConnection and SqlCommand into using blocks    
    using (dbConnection cn = new dbConnection())
    using (SqlCommand cmd = new SqlCommand(query, cn))
    {
        // define the parameter value
        cmd.Parameters.Add("@StudentID", SqlDbType.UniqueIdentifier).Value =  dropdown_student.SelectedValue;
    
    	cn.Open();
    	
        // use ExecuteScalar if you fetch one row, one column exactly
    	object result = cmd.ExecuteScalar();
    	cn.Close();
    	
    	if(result != null)
    	{
    		int value = (int)result;
    		textbox_total.Text = value.ToString();
    	}
    }
