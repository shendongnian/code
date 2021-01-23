    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ValidateEmail(txtEmail.Text))
                args.IsValid = true; 
            else
                args.IsValid = false;
        }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
            //Carry on
        else
           //Validator has failed, ask user to correct.
    }
