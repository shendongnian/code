    public static class DataUtilities
    {
        public static void ApplyAttributes<T>(T obj)
        {
            // Capitalization attribute
            var props = typeof (T).GetProperties().Where(p => p.GetCustomAttributes(typeof (CaptializationAttribute), true).Any());
            foreach (var prop in props)
            {
                // This is just an example, if you use this code you 
                // should check if the property is a string first!
                prop.SetValue(obj, prop.GetValue(obj).ToString().ToUpper());
                // Or perform some other manipulation here.
            }
        }
    }
