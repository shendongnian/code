    [Fact]
    public void Container_CompositePropertyManager_CallsAllMatchers()
    {
        var container = new Container();
        container.RegisterAll<IPropertyMatcher>(this.GetPropertyMatchers());
        container.Register<IPropertyMatcher, CompositePropertyMatcher>();
        var composite = container.GetInstance<IPropertyMatcher>();
        Assert.True(composite.IsMatch(
            new Property { Name = "a", Address = "b", Latitude = 1m, Longitude = 2m },
            new Property { Name = "a", Address = "b", Latitude = 3m, Longitude = 4m }));
        Assert.True(composite.IsMatch(
            new Property { Name = "a", Address = "b", Longitude = 1m, Latitude = 2m },
            new Property { Name = "c", Address = "d", Longitude = 1m, Latitude = 2m }));
        Assert.False(composite.IsMatch(
            new Property { Name = "a", Address = "b", Longitude = 1m, Latitude = 2m },
            new Property { Name = "c", Address = "d", Longitude = 3m, Latitude = 4m }));
    }
    private IEnumerable<Type> GetPropertyMatchers()
    {
        var result =
            from type in typeof(IPropertyMatcher).Assembly.GetTypes()
            where !type.IsAbstract
            where typeof(IPropertyMatcher).IsAssignableFrom(type)
            where type != typeof(CompositePropertyMatcher)
            select type;
        return result;
    }
