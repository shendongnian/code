    foreach (var dependentProperty in dependentPropertyInfos)
    {
        var property
            = dependentEnd.GetEntityType() // -> SER
                .GetDeclaredPrimitiveProperty(dependentProperty); // -> VersionId
        if (property == null) // VersionId is not part of SER metamodel
        {
            throw Error.ForeignKeyPropertyNotFound(
                dependentProperty.Name, dependentEnd.GetEntityType().Name);
        }
        dependentProperties.Add(property);
    }
