    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Update DB first
        UpdateProjectDetails(txtPrjID.Text, txtPrjNmae.Text, txtPrjdescription.Text, txtPrjDate.Text, txtPrjSize.Text, txtPrjManager.Text);
        // Fetch new results from DB
        IEnumerable<ProjectDetail> projectDetails = GetProjectDetails();
        // Update UI
        dataGridView2.DataSource = projectDetails;
        dataGridView2.Update();
        dataGridView2.Refresh();
        // Alert the user
        MessageBox.Show("Project Details are updated");
    }
    public void UpdateProjectDetails(string prjID, string prjName string description, string date, string size, string manager)
    {
        using (DbConnection con = Helper.getconnection())
        {
            con.Open();
            DbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Projects set ProjectName= '" + PrjName + "', Description='" + Description + "', DateStarted='" + Date + "',TeamSize='" + Size + "',Manager='" + Manager + "' where ProjectID= " + PrjID + " ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
    }
