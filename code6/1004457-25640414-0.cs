    public static class EnumExtensions
    {
        public static int ToInt(this Enum enum)
        {
            return (int)((object)enum);
        }
    }
