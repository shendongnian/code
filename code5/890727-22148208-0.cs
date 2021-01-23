    //NOTE: This code will not catch double periods, extra spaces. For more precision, stick to Regex.
    public bool IsEmailValid(string emailAddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailAddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
