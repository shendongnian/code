    public static class EnumHelper
    {
        public static int Count(Type e)
        {
            // use reflection to check that e is an enum
    
            return Enum.GetNames(e).Length;
        }
    }
