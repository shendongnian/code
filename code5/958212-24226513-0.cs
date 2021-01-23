    private string GetOrder<T>(IEnumerable<T> list)
        where T : class
    {
        // Comparer class to see greater or less than or equal
        var comparer = Comparer.Default;
        // Track currrent orderby so far
        var propsOrderBy = typeof (T).GetProperties().ToDictionary(p => p, _ => 0);
        // List of all the property since we can update dictionary if we iterate over it
        var props = new List<PropertyInfo>(propsOrderBy.Keys);
        // Last value
        var previousValues = new Dictionary<string, object>();
        // Need to iterate over list to compare data
        foreach (var data in list)
        {
            // Check each property if we haven't removed it yet
            foreach (var prop in props.Where(propsOrderBy.ContainsKey))
            {
                var value = prop.GetValue(data);
                if (previousValues.ContainsKey(prop.Name))
                {
                    var comparison = comparer.Compare(value, previousValues[prop.Name]);
                    // If comparison didn't say it was equal and it's not the same as the previous order by
                    if (comparison != 0 && (comparison != propsOrderBy[prop]))
                    {
                        // If zero first time setting it
                        if (propsOrderBy[prop] == 0)
                        {
                            propsOrderBy[prop] = comparison;
                        }
                        else
                        {
                            // Not our order key so remove it
                            propsOrderBy.Remove(prop);
                        }
                    }
                }
                // Store last value
                previousValues[prop.Name] = value;
            }
        }
        if (previousValues.Any() && propsOrderBy.Any())
        {
            return String.Join(", ", propsOrderBy.Select(p => p.Key.Name + (p.Value < 0 ? " desc" : " asc ")));
        }
        else
        {
            return "none";
        }
    }
