    public static class NameValuePairExtensions
    {
        public static List<NameValuePair> GetNamedValues<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
            var type = obj.GetType();
            var properties = type.GetProperties();
            List<NameValuePair> list = new List<NameValuePair>();
            foreach (var prop in properties)
            {
                if (prop.PropertyType == typeof(string))
                {
                    var getter = prop.GetGetMethod();
                    var setter = prop.GetSetMethod();
                    if (getter != null && setter != null) // Confirm this property has public getters & setters.
                    {
                        list.Add(new NameValuePair() { Name = prop.Name, Value = (string)getter.Invoke(obj, null) });
                    }
                }
            }
            return list;
        }
        public static void SetNamedValues<T>(T obj, IEnumerable<NameValuePair> values)
        {
            if (obj == null || values == null)
                throw new ArgumentNullException();
            var type = obj.GetType();
            foreach (var value in values)
            {
                var prop = type.GetProperty(value.Name);
                if (prop == null)
                {
                    Debug.WriteLine(string.Format("No public property found for {0}", value));
                    continue;
                }
                try
                {
                    prop.SetValue(obj, value.Value, null);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception setting " + value.ToString() + " : \n" + ex.ToString());
                }
            }
        }
    }
