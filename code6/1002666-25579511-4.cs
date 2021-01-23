    var persister = factory.GetClassMetadata(entityType) as AbstractEntityPersister;
    var propertyNameList = persister.PropertyNames;
    foreach (var propertyName in propertyNameList)
    {
        // many info is in collections, so we need to know the index
        // of our property
        var index = persister.GetPropertyIndex(propertyName);
        // with index, we can work with the mapped type
        var type = persister.PropertyTypes[index];
        // if the type is OneToOne... we can observe
        if(type is NHibernate.Type.OneToOneType)
        {
            Console.Write(type.IsAssociationType);
            Console.Write(type.IsAnyType);
            Console.Write(type.IsMutable);
            Console.Write(type.IsCollectionType);
            Console.Write(type.IsComponentType);
            Console.Write(type.ReturnedClass);
            ...
            // many other interesting and useful info could be revealed
        }
    }
