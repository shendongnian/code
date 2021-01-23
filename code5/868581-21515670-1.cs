    private void btnAdminLogin_Click(object sender, EventArgs e)
    {
        if (txtAdminUsername.Text=="<hardcoded_Username>" && txtAdminPasswd.Text=="<hardcoded_Password>")
        {
             //Login as Hardcoded User
             MessageBox.Show("Login Successful") == DialogResult.OK
             //Do your stuff
             return;
        }
        //retrieve connection information info from App.config
        string strConnectionString = ConfigurationManager.ConnectionStrings["SACPConnection"].ConnectionString;
        //STEP 1: Create connection
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        //STEP 2: Create command
        //For WindowsAdmin
        string strCommandtext = "SELECT * from WINDOWSADMIN";
        strCommandtext += "   WHERE winUsername=@aname AND winPassword=@apwd;";
        SqlCommand cmd = new SqlCommand(strCommandtext, myConnect);
        //For WindowsAdmin
        cmd.Parameters.AddWithValue("@aname", txtAdminUsername.Text);
        cmd.Parameters.AddWithValue("@apwd", txtAdminPasswd.Text);
        try
        {
            // STEP 3: open connection and retrieve data by calling ExecuteReader
            myConnect.Open();
            // STEP 4: Access Data
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) //For WindowsAdmin
            {
                if (MessageBox.Show("Login Successful") == DialogResult.OK)
                {
                    admin form = new admin(txtAdminUsername.Text);
                    form.Show();
                    /*
                    login loginForm = new login();
                    this.Visible = false;
                    this.Hide();
                    adminLogin AdminloginForm = new adminLogin();
                    this.Visible = false;
                    this.Hide();
                    */
                    return;
                }
            }
            //STEP 5: close connection
            reader.Close();
            MessageBox.Show("Invalid username or password ");
        }
    }
