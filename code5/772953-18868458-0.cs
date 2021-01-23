    // pseudo code!
    
    // for every type in assembly...
    foreach (var targetType in assembly.Types)
    {
        // find type which adds attributes to original type
        var sourceTypeName = targetType.Name + "Attributes";
        var sourceType = assembly.Types.FirstOfDefault(t => t.Name = sourceTypeName);
        
        if (sourceType == null) continue; // no type adding attributes
        
        // for each property in this type...
        foreach (var targetProperty in targetType.Properties)
        {
            // find property which is supposed to have additional attributes
            var sourceProperty = sourceType.Properties.FirstOfDefault(
                p => p.Name = targetProperty.Name);
            if (sourceProperty == null) continue; // no such property
            
            // copy attributes
            foreach (var sourceAttribute in sourceProperty.Attributes)
            {
                targetProperty.Attributes.Add(sourceAttribute);
            }
        }
    }
