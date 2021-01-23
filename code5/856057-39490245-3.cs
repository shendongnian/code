    // Assign the property names
    var navigablePropertyNames = new[]
    {
        nameof(ParentEntity.Id),
        nameof(ParentEntity.Name),
        nameof(ParentEntity.Description)
    };
    
    // Do the inclusion
    GetAll(navigablePropertyNames);
