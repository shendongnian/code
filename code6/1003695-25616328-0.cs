    public class StringVarCharConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property.PropertyType == typeof (string))
                instance.CustomType("AnsiString");
        }
    }
