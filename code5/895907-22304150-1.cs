    String strName = txtName.Text;
    String strEmail = txtEmail.Text;
    Boolean blnErrors = false;
    
    if (string.IsNullOrWhiteSpace(sstrName))
    {
        string script = "alert(\"Name Field Is Required!\");";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        txtName.Focus();
    }
