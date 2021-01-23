    public static class MyExtensions
    {
        public static string SmartToString(this object instance)
        {
            if(instance == null)return "";
            return instance.ToString()
        }
    }
