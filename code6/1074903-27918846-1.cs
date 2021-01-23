    public static class EnumHelper
    {
        public static int Count(Type e)
        {
            // use reflection to check that e is an enum
            // or just wait for the Enum method to fail
    
            return Enum.GetNames(e).Length;
        }
    }
