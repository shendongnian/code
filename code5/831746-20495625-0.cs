    private void LoginBTN_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=Abdullah-PC;Initial Catalog=SmartPharmacyDB;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "select userpass from usertab where username = @username";
        com.Parameters.Add("@username", usernametxt.Text);
        con.Open();
        string returneduserpass = com.ExecuteScalar().ToString();
        con.Close();
        if (returneduserpass == userpasstxt.Text)
        {
            Smart_Pharmacy f = new Smart_Pharmacy();
            f.Show();
            this.Close();
         }
         else
         {
            MessageBox.Show("Incorrect username or password !");
         }
    }
