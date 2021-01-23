     protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string AdminNumber = Convert.ToString(txtAdmin.Text);
        string Name = Convert.ToString(txtName.Text);
        string BlogStory = Convert.ToString(txtStory.Text);
        // get value or dropdown
        string BlogType = drpBlogType.SelectedValue;
        
            insertGameRecord(AdminNumber, Name, BlogStory,BlogType);
        }
        
        private void insertGameRecord(string admin, string name, string story,string BlogType)
        {
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
                SqlConnection myConnect = new SqlConnection(strConnectionString);
        
                string strCommandText = "INSERT EntryTable(AdminNumber, Name, BlogStory, DateEntry,BlogType) Values(@AdminNumber, @Name, @BlogStory, @DateEntry,@BlogType)";
        
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        
                cmd.Parameters.AddWithValue("@AdminNumber", admin);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@BlogStory", story);
                cmd.Parameters.AddWithValue("@BlogType", BlogType);
                cmd.Parameters.Add("DateEntry", SqlDbType.DateTime);
                cmd.Parameters["DateEntry"].Value = DateTime.Now;
        
                myConnect.Open();
        
                int result = cmd.ExecuteNonQuery();
        
                if (result > 0)
                { lblError.Text = "Record Updated"; 
                 bindResultGridView();
                }
        
                else { lblError.Text = "Update fail"; }
        
                myConnect.Close();
            }
            catch(Exception)
            {
                lblError.Text = "Please enter correct data";
            }
        
        
        }
