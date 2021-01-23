    public class PropertyEmptySetter<T> where T : class
    {
        public PropertyEmptySetter()
        {
        }
    
        public void UpdateStringProperties()
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType == (typeof(string)))
                {
                    if(prop.GetValue(this) == null)
                        prop.SetValue(this, String.Empty);
                }
            }
        }
    }
