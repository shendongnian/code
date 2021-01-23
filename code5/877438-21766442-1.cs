    bool UserReusedPassword(string username, string password)
    {
        foreach(string oldHash in GetOldHashesForUser(username)
        {
            if(UserManager.PasswordHasher.VerifyHashedPassword(oldHash, password) != PasswordVerificationResult.Failed)
            {
                return true;
            }
        }
    
        return false;
    }
