     protected void loginButton_Click(object sender, EventArgs e)
    {
    
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True;Pooling=False";
    
    
        Int32 verify;
        string query1 = "Select count(*) from Login where ID='" + idBox.Text + "' and Password='" + passwordBox.Text + "' ";
        SqlCommand cmd1 = new SqlCommand(query1, con);
        con.Open();
        verify = Convert.ToInt32(cmd1.ExecuteScalar());
        con.Close();
        if (verify > 0)
        {
            Response.Redirect("succesful.aspx");
        }
        else
        {
            Response.Redirect("unsuccesful.aspx",true);
        }
    
    }
