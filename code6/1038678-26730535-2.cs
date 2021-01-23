    const string Agent1 = "Agent1";
    public class AgentEvaluator : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            switch (agencyProperty.AgentType)
            {
                case Agent1:
                    return agencyProperty.Name == databaseProperty.Name && agencyProperty.Address == databaseProperty.Address;
                case Agent2:
                    ...
            }
        }
    }
