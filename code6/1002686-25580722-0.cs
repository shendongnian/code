        string Connection = "Data Source=(ip);Initial Catalog=..;Persist Security Info=True;User ID=(id);Password=(pass)";
        SqlConnection myConn = new SqlConnection(Connection);
        
        SqlCommand SelectCommand = new SqlCommand("select * from tar_login where Username ='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "' and Position='" + ddlPosition.Text + "';", myConn);
        
        myConn.Open();
        
        Sqldatareader myReader = SelectCommand.ExecuteReader();
        myConn.Close();
        
         if (reader.HasRows)
            {
    if (ddlPosition.Text == "Admin")
            {
                Response.Redirect("manager.aspx");
            }
    else if (ddlPosition.Text == "Staff")
            {
                Response.Redirect("staff.aspx");
            }
        else
        {
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "Incorrect. Please try again";
            myConn.Close();
        }
