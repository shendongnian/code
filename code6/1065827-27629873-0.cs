    static class ObjectExtends
    {
        public static T GetAttribute<T>(this object obj) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(obj.GetType(), typeof(T));
        }
        public static T GetAttribute<T>(Type t) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(t, typeof(T));
        }
    }
