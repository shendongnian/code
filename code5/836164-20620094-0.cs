    public static class MyExtensions
    {
        public static string ToUpperString(this UserStatus userStatus)
        {
            return userStatus.ToString().ToUpper();// OR .ToUpperInvariant 
        }
    }
