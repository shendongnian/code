    class EnumHandlingConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Type.IsEnum)
            {
                instance.CustomType<SpecialEnumUserType>();
            }
        }
    }
