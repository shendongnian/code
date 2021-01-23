    private bool isValid(string UserName, string Password)
       {
            //returns true if there is any match, false if no match
            return db.User.Any(u=> u.UserName == UserName);   
       }
