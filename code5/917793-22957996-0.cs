    private bool ChangePassword()
    {
        string CS = ConfigurationManager.ConnectionStrings["ABCD"].ConnectionString;
        using(SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spChangePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email",txtEmail.Text);
            cmd.Parameters.AddWithValue("@Passwordd", txtPassword.Text);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
                return true;
            else
                return false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool success = ChangePassword(); //Use this success variable to show a message.
    }
