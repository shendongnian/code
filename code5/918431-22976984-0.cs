    class ModelClass
    {
        public SomethingType MyType {get; set;}
        public string TypeName {
            get
            {
                var enumType = typeof(SomethingType);
                var field = enumType.GetFields()
                           .First(x => x.Name == Enum.GetName(enumType, MyType));
                var attribute = field.GetCustomAttribute<Display>();
                return attribute.Name;
            }
    }
