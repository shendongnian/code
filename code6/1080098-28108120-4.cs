    public static class PropertyEmptySetter
    {
        public static T UpdateStringProperties<T>(this T obj) where T : class
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.PropertyType == (typeof(string)))
                {
                    if(prop.GetValue(obj) == null)
                        prop.SetValue(obj, String.Empty);
                }
            }
            
            return obj;
        }
    }
