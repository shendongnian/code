    private IEnumerable<Component> EnumerateComponents()
    {
        var compType = typeof(Component);
        var ctrlType = typeof(Control);
        return this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
               .Where(f => compType.IsAssignableFrom(f.FieldType))
               .Where(f => !ctrlType.IsAssignableFrom(f.FieldType))
               .Select(f => f.GetValue(this))
               .OfType<Component>();
    }
