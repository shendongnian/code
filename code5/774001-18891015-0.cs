    public static class EnumExtension
    {
        public static string ToCompleteName(this Color c)
        {
            return "Color." + c.ToString();
        }
    }
