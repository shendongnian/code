    String strName = txtName.Text.Trim(); //add trim here
    String strEmail = txtEmail.Text;
    Boolean blnErrors = false;
    
    if (string.IsNullOrWhiteSpace(sstrName)) //this function checks for both null or empty string.
    {
        string script = "alert(\"Name Field Is Required!\");";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        txtName.Focus();
        return;//return from the function as there is an error.
    }
    //continue as usual .
