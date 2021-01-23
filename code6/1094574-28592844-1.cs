    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                SqlConnectionStringBuilder conBuild = new SqlConnectionStringBuilder();
                conBuild.InitialCatalog = "dbFileUploadDemo";
                conBuild.DataSource = @"localhost\sqlexpress";
                conBuild.IntegratedSecurity = true;
                string uploadDirectory = @"e:\uploads";
                Guid idFile = Guid.NewGuid();
                using (SqlConnection con = new SqlConnection(conBuild.ConnectionString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("insert into tblFiles (idFile, fileName) values (@idFile, @fileName)", con);
                    com.Parameters.AddWithValue("fileName", FileUpload1.FileName);
                    com.Parameters.AddWithValue("idFile", idFile);
                    com.ExecuteNonQuery();
                    string fileName = Path.Combine(uploadDirectory, idFile.ToString());
                    FileUpload1.SaveAs(fileName);
                }
                lblStatus.Text = "File uploaded";
            }
            catch (Exception ex)
            {
                // insert logging and exception handling here
                Debug.WriteLine(ex.Message);
                
                lblStatus.Text = "Error!";
            }
        }
        else
        {
            lblStatus.Text = "Please select file!";
        }
    }
