    public static class DefaultExtension
    {
        public static void SetDefaults<T>(this T toDefault)
        {
            foreach (PropertyInfo p in toDefault.GetType().GetProperties())
            {
                foreach (var dv in p.GetCustomAttributes(true).OfType<DefaultValueAttribute>())
                {
                    p.SetValue(toDefault, dv.Value, null);
                }
            }
        }
    } 
