    public void CreateProject_Click(object sender, EventArgs e)
    { 
        var insCmd = new SqlCommand("INSERT INTO Projects (TesterName, ProjectName, ProjectDescription, DueDate, DateAssigned, Platform) values (@TesterName, @ProjectName,@ProjectDesc, @DueDate, @DateAssigned, @Platform)");
        insCmd.Parameters.AddWithValue("@ProjectName", txtProjectName);
        insCmd.Parameters.AddWithValue("@ProjectDesc", txtProjectDesc);
        insCmd.Parameters.AddWithValue("@TesterName", ddlTester.SelectedItem); //This should probably be .SelectedValue instead
        insCmd.Parameters.AddWithValue("@DateAssigned", txtStartDate);
        insCmd.Parameters.AddWithValue("@DueDate", txtEndDate);
        insCmd.Parameters.AddWithValue("@Platform", TxtProjectPlatform);
        using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString))
        {
            insCmd.Connection = cnn;
            cnn.Open();            
            insCmd.ExecuteNonQuery();
            cnn.Close();
        }
        
       ClientScript.RegisterStartupScript(this.GetType(), "insert-success", "alert('Project created');", true);
    }
