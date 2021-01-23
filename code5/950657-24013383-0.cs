    public class CustomTypeConvention : IUserTypeConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType == typeof(MyType));
        }
        public void Apply(IPropertyInstance target)
        {
            target.CustomType(typeof(string));
        }
    }
