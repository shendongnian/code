    public static class UserExtensionMethods
    {
        public static string FirstLetterOfFirstName(this User user)
        {
            return user.FirstName.Substring(0, 1);
        }
    }
