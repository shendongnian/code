    protected void btnAuthenticate_Click(object sender, EventArgs e)
    {
        string EPass = Helper.ComputeHash(txtPassword.Text, "SHA512", null);
        if (EPass == lblmsg.Text) 
        {
            Label1.Text = "You are the correct user";       
        }
    }
