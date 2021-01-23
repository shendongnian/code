    bool IsValidEmail(string email)
    {
        try {
            var mail = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch {
            return false;
        }
    }
 
    
