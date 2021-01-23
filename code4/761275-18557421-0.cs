    public ActionResult VerifyPassword(User user)
            {
                //The ".FirstOrDefault()" method will return either the first matched
                //result or null
                User myUser = dbContext.Users.FirstOrDefault
                    (u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));
    
                if (myUser != null)   
                {
                    //User was found
                    //Proceed with your login process...
                }
                else    //User was not found
                {
                    //Do something to let them know that their credentials were not valid
                }
            }
