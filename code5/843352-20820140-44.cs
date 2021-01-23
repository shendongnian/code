    public static void CheckAllPropertiesAreNotNull<T>(this T objectToInspect, 
                                         params Expression<Func<T, object>>[] getters)
    {
        var defaultProperties = getters.Where(f => f.Compile()(objectToInspect).IsDefault());
        if (defaultProperties.Any())
        {
            var commaSeparatedPropertiesNames = string.Join(", ", defaultProperties.Select(GetName));
            Assert.Fail("expected next properties not to have default values: " + commaSeparatedPropertiesNames);
        }
    }
