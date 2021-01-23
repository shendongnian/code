    public class Agent1Evaluator : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return agencyProperty.Name == databaseProperty.Name && agencyProperty.Address == databaseProperty.Address;
        }
    }
