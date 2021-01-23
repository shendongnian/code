    private IEnumerable<Component> EnumerateComponents()
    {
        return this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
               .Where(f => typeof(Component).IsAssignableFrom(f.FieldType))
               .Where(f => !typeof(Control).IsAssignableFrom(f.FieldType))
               .Select(f => f.GetValue(this))
               .OfType<Component>();
    }
