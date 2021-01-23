    public static class EM
    {
        public static string FirstLetterOfFirstName(this User user)
        {
            return user.FirstName.Substring(0, 1);
        }
    }
