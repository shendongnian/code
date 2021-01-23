    public static void CheckAllPropertiesAreNotNull<T>(this T objectToInspect, 
                                                    params Func<T, object>[] getters)
    {
        if (getters.Any(getter => getter(objectToInspect) == null))
            Assert.Fail("some of the properties are null");
    }
    
