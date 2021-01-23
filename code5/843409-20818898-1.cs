    class RootClass
    {
        public Class1 propClass1 { get; set; }
        public Class2 propClass2 { get; set; }
        public Class3 propClass3 { get; set; }
        public BaseClass GetPropertyByName(string propertyName)
        {
            PropertyInfo pi = typeof(RootClass).GetProperty(propertyName);
            return pi.GetValue(instance, null) as BaseClass;
        }
    }
