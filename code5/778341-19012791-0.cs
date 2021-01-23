    protected override List<Assembly> ValueConverterAssemblies
    {
        get
        {
            var toReturn = base.ValueConverterAssemblies;
            toReturn.Add(typeof(BoolToVisibilityValueConverter).Assembly);
            return toReturn;
        }
    }
