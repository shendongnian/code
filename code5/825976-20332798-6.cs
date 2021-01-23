    private bool IsEmailValid(string mail)
    {
        try
        {                
            MailAddress eMailAddress = new MailAddress(mail);
            return true;
        }
        catch (FormatException)
        {
            return false;  
        }
    }
