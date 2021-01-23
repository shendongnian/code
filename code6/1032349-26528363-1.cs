    private bool checkMailLL(string mail)
    {
        if (string.IsNullOrEmpty(mail))
           return false;    
 
        try
        {
            var test = new MailAddress(mail);
            return true; //valid email
        }
        catch (FormatException ex)
        {
            return false; //invalid email
        }
    }
