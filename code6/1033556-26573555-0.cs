    internal static bool CheckSecretCodeLoginkError(String License, String SecretCode, DataClasses1DataContext db)
    {
        // you store a reference in "user" here.....
        User user = db.Users.Where(a => a.Licensekey == License).Single();
    
        if (SecretCode != user.SecretCode && !user.SkipSecretCode)
        {
            if (user.LastSecretChangeDate > DateTime.UtcNow - TimeToPreventSecretCodeChange)
            {
                //secret error
                return true;
            }
            else
            {
                //no error
                //update secret code and last change
                // **REUSE** that reference you stored above!! 
                // Don't call .Where(...).Select(....).First() again!
                user.LastSecretChangeDate = DateTime.UtcNow;
                user.SecretCode = SecretCode;
    
                db.SubmitChanges();
    
                return false;
            }
        }
        else
        {
            return false;
        }
    }
