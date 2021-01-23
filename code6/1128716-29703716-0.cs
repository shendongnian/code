    public static class Helper
    {
        public static bool In<T>(this T value, params T[] args)
        {
            for (int i = 0; i < args.Length; i++)
                if (value.Equals(args[i]))
                    return true;
            return false;
        }
    }
