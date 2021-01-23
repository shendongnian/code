    public static class UserExtensions
    {
        public static string FirstLetterOfFirstName(this User user) 
        {
            return user.FirstName.Substring(0,1);
        }
    }
    // In your code
    User u = new User();
    u.FirstLetterOfFirstName();
