    modelBuilder.Types().Configure(typeConfiguration =>
    {
        foreach (var property in typeConfiguration.ClrType
            .GetProperties().Where(p => p.PropertyType.IsEnum))
        {
            typeConfiguration.Ignore(property);
        }
    });
