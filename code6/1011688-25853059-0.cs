    public class VM_MyClass
    {
        private static Type ThisType = typeof(VM_MyClass);
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public object this[string propertyName]
        {
            get
            {
                return GetValueUsingReflection(propertyName);
            }
            set
            {
                SetValueUsingReflection(propertyName, value);
            }
        }
        private void SetValueUsingReflection(string propertyName, object value)
        {
            PropertyInfo pinfo = ThisType.GetProperty(propertyName);
            pinfo.SetValue(this, value, null);
        }
        private object GetValueUsingReflection(string propertyName)
        {
            PropertyInfo pinfo = ThisType.GetProperty(propertyName);
            return pinfo.GetValue(this,null);
        }
    }
