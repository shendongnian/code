    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        try
        {
            int i = users.AddNewUser();
            if (i != 0)
            {
    ScriptManager.RegisterStartupScript(this, GetType(), "btnSignUp", "showLoader()", true);
    
            }
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
