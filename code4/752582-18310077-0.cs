    public void ListViewDetails_ItemEditing(object sender, System.Web.UI.WebControls.ListViewEditEventArgs e)
    {
        string connectionString = "??";
        
        using (SqlConnection sqlConn = new SqlConnection(connectionString)) {
            
            using (SqlCommand cmd = new SqlCommand("dbo.RegisterUpdate", sqlConn)) {
                
                cmd.CommandType = CommandType.StoredProcedure;
    			cmd.Parameters.AddWithValue("@id", ????);
                cmd.Parameters.AddWithValue("@fname", (TextBox)e.NewValues["fname"]);
                cmd.Parameters.AddWithValue("@lname", (TextBox)e.NewValues["lname"]);
                cmd.Parameters.AddWithValue("@company", (TextBox)e.NewValues["company"]);
                cmd.Parameters.AddWithValue("@email", (TextBox)e.NewValues["email"]);
    
                try {
                    sqlConn.Open();
                }
                catch (Exception ex) {
                    //handle exception
                }
                
                try {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) {
                    //handle exception
                }
            }
        }
    }
