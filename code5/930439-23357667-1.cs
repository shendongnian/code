        private void btnSave_Click(object sender, EventArgs e)
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["HeuristicDatabaseConnectionString"].ConnectionString;
    
            SqlConnection myconnection = new SqlConnection(strConnectionString);
    
            String strCommandText = "INSERT Form(Location,Violation,Recommendation)"
               + " VALUES(@Location,@Violation,@Recommendation)";
            SqlCommand Cmd = new SqlCommand(strCommandText, myconnection);
    
            myconnection.Open();
    
            for (int a = 0; a <= i; a++)
            {
                Cmd.Parameters.Clear();    // clear the parameters so that previous values are cleared
    
                testing = (RichTextBox)this.Controls.Find("testing" + a.ToString(), true)[0];
                Cmd.Parameters.AddWithValue(@"Location", testing.Text);
    
                lol = (RichTextBox)this.Controls.Find("lol" + a.ToString(), true)[0];
                Cmd.Parameters.AddWithValue(@"Violation", lol.Text);
    
                haha = (ComboBox)this.Controls.Find("haha" + a.ToString(), true)[0];
                Cmd.Parameters.AddWithValue(@"Recommendation", haha.SelectedItem);
    
                Cmd.ExecuteNonQuery();
            }
            myconnection.Close();
        }
