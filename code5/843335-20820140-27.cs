    public static void CheckAllPropertiesAreNotNull<T>(this T objectToInspect, 
                                                    params Func<T, object>[] getters)
    {
        if (getters.Any(f => f(objectToInspect).IsDefault()))
            Assert.Fail("some of the properties are not null");
    }
