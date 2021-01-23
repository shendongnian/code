    // Assign the property names
    var navigablePropertyNames = String.Join(".",
        nameof(ParentEntity.Id),
        nameof(ParentEntity.Name),
        nameof(ParentEntity.Description));
    
    // Do the inclusion
    myQueryable.Include(navigablePropertyNames);
