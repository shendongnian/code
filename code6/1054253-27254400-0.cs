    public static class ThrowOn
    {
        public static T Null<T>(T val, string name) where T : object
        {
            if (val == null) throw new ArgumentNullException(name);
            return val;
        }
    }
