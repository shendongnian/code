    public static class AnonHelpers
    {
        public static object MatchAnonymousType(object expected)
        {
            return Match.Create(Matcher(expected));
        }
        private static Predicate<object> Matcher(object expected)
        {
            return actual =>
            {
                var expectedProp = expected.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(expected));
                var actualProp = actual.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(actual));
                foreach (var prop in expectedProp)
                {
                    if (!actualProp.ContainsKey(prop.Key))
                        return false;
                    if (!prop.Value.Equals(actualProp[prop.Key]))
                        return false;
                }
                return true;
            };
        }
    }
