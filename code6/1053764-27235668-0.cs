    public IEnumerable<Component> EnumerateComponents()
    {
        return this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => typeof(Component).IsAssignableFrom(x.PropertyType))
            .Select(x => x.GetValue(this)).Cast<Component>();
    }
