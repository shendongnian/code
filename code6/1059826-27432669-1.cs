    public static class MyExtensions
    {
        public static Int16 ToDbValue(this string sex)
        {
            switch (sex.ToLower())
            {
                case "male":
                    return 0;
                case "female":
                    return 1;
                default:
                    // throw exception, or return what you want as default
             }
        }
    }
