    public static class Extensions
    {
        public static T ThrowOnNull<T>(this T val, string name) where T : object
        {
            if (val == null) throw new ArgumentNullException(name);
            return val;
        }
    }
