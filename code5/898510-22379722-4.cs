    class PropertyAccessor
    {
        private string[] properties;
        public PropertyAccessor (string path)
        {
            properties = path.Split('.');
        }
        private object GetValue (object obj, string property)
        {
            return obj.GetType().GetProperty(property).GetValue(obj);
        }
        private void SetValue (object obj, string property, object value)
        {
            return obj.GetType().GetProperty(property).SetValue(obj, value);
        }
        public object Get (object obj)
        {
            object o = obj;
            for (int i = 0; i < properties.Length; i++)
            {
                o = GetValue(o, properties[i]);
            }
            return o;
        }
        public void Set (object obj, object value)
        {
            object o = obj;
            for (int i = 0; i < properties.Length - 1; i++)
            {
                o = GetValue(o, properties[i]);
            }
            SetValue(o, properties[properties.Length - 1], value);
        }
    }
