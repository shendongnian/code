     protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtUID.Text.Length == 0 || txtPass.Text.Length == 0)
        {
             Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", "alert('Please type your User ID and Password correctly and click Submit button again.  Thanks');", true);
        }
        else
        {
            //execute some code here
        }
    }
