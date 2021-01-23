    public class PropertyEmptySetter<T> where T : class
    {
        public void UpdateStringProperties()
        {
            UpdateStringProperties(this as T);
        }
    
        public static T UpdateStringProperties(T obj)
        {
            if (obj == null)
            {
                return null;
            }
            
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
