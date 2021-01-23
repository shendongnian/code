    class RootClass
    {
        public enum PropertyEnum
        {
            propClass1,
            propClass2,
            propClass3
        }
        public Class1 propClass1 { get; set; }
        public Class2 propClass2 { get; set; }
        public Class3 propClass3 { get; set; }
        public BaseClass GetPropertyByEnum(RootClass.PropertyEnum enumValue)
        {
            PropertyInfo pi = typeof(RootClass).GetProperty(enumValue.ToString());
            return pi.GetValue(instance, null) as BaseClass;
        }
    }
