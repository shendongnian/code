    public class PropertyMockAutoDataAttribute : PropertyAutoDataAttribute
    {
        public PropertyFakeAutoDataAttribute(string propertyName)
            : base(propertyName, new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
