    public static class ObjectExtensions
    {
        public static void CopyProperties<T>(this T fromObj, T toObj)
        {
            foreach(var p in typeof(T).GetProperties()) 
            {
                p.SetValue(toObj, p.GetValue(fromObj, null), null);
            }
        }
    }
