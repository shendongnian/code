    protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        if(e.Contains("-"))
        {
            e.IsValid = false;
        }
        else
        {
            e.IsValid = true;
        }
    }
