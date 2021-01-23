    public class CompositePropertyMatcher : IPropertyMatcher
    {
        private readonly IEnumerable<IPropertyMatcher> matchers;
        public CompositePropertyMatcher(IEnumerable<IPropertyMatcher> matchers)
        {
            this.matchers = matchers;
        }
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return this.matchers.Any(m => m.IsMatch(agencyProperty, databaseProperty));
        }
    }
    public class PropertyMatcher1 : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return agencyProperty.Name == databaseProperty.Name
                && agencyProperty.Address == databaseProperty.Address;
        }
    }
    public class PropertyMatcher2 : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return agencyProperty.Longitude == databaseProperty.Longitude
                && agencyProperty.Latitude == databaseProperty.Latitude;
        }
    }
