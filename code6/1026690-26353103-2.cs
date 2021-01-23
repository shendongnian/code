    public static class Extension
    {
        public static T GetCustomAttribute<T>(this System.Reflection.MemberInfo mi) where T : Attribute
        {
            return mi.GetCustomAttributes(typeof (T),true).FirstOrDefault() as T;
        }
    }
