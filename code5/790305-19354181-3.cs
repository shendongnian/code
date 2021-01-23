    class EnumHandlingConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Type == typeof(TheSpecialEnum))
            {
                instance.CustomType<SpecialEnumUserType>();
            }
        }
    }
