        SqlDataAdapter da = 
                new SqlDataAdapter("SELECT c_id,c_name FROM category",
                new SqlConnection
               (WebConfigurationManager.ConnectionStrings
               ["ApplicationServices"].ToString())); 
                DataSet ds = new DataSet();
                da.Fill(ds, "AccountM ");
                checkedListBox1.DataSource = ds; 
                checkedListBox1.SelectedValue = "c_id";
                checkedListBox1.SelectedItem = "c_name ";
