    public static class Extensions
    {
        public static T Initialize<T>(this T value, Action<T> initializer) where T : class
        {
            initializer(value);
            return value;
        }
    }
