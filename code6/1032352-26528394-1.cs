    private bool checkMailLL(string mail)
    {
        if(string.IsNullOrWhiteSpace(mail)) return false;
        try
        {
            var test = new MailAddress(mail);
            return true; //valid email
        }
        catch (FormatException )
        {
            return false; //invalid email
        }
    }
