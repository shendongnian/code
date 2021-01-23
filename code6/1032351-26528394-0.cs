    private bool checkMailLL(string mail)
    {
        try
        {
            var test = new MailAddress(mail);
            return true; //valid email
        }
        catch (FormatException)
        {
            return false; //invalid email
        }
        catch (ArgumentException)
        {
            return false; //invalid email
        }
    }
