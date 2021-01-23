    protected void ListViewDetails_ItemUpdating(object sender, ListViewUpdateEventArgs e)
            {
                TextBox fname = (TextBox)e.NewValues["fname"];
                TextBox lname = (TextBox)e.NewValues["lname"];
                TextBox company = (TextBox)e.NewValues["company"];
                TextBox email = (TextBox)e.NewValues["email"];
    
    
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.RegisterUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
    
    
    
                cmd.Parameters.AddWithValue("@fname", Convert.ToInt16(fname.Text));
                cmd.Parameters.AddWithValue("@lname", lname.Text);
                cmd.Parameters.AddWithValue("@company", company.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
    
            }
