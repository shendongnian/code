    public bool LogIn(string userID, string password)
    {
        using (Entity.AMLEntities en = new AMLEntities())
        {
            try
            {
                string hashed = this.SetPassword(password);
                var user = en.Users.SingleOrDefault(x => x.LoginID == userID && x.PasswordHash == hashed);
                if (user != null && password != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
    
        }
    }
