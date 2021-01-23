    [NonAction]
        public bool ValidateUser(string userName, string password)
        {
            // Check if it is valid credential  
            var queryable = db.Auths
                            .Where(x => x.Name == userName)
                            .Where(x => x.Password == password);
            if (queryable != null)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
