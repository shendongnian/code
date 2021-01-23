    protected void ServerValidation (object source, ServerValidateEventArgs args)
    {
    	// default to valid
    	args.IsValid = true;
    	int i;
    	if (int.TryParse(Text1.Text.Trim(), out i) == false)
    	{
    		// validation failed, flag invalid
    		args.IsValid = false;
    		CustomValidator1.ErrorMessage = "The value " + Text1.Text.Trim() + " is not a valid integer";
    	}
    }
