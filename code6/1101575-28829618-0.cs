    var simpleProperties = typeMapper.GetSimpleProperties(entity);
        if (simpleProperties.Any())
        {
    		var extraProperties = new List<EdmProperty>(); // Instantiates a new list to hold the new properties for the current entity
    
            foreach (var edmProperty in simpleProperties) // Loops through all the current simple properties
            {
    			if (edmProperty.PrimitiveType == PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Boolean)) // If the property type is Boolean, We will add a new DateTime property
    			{
    				string dtPropName = string.Format("{0}ChangedAt", edmProperty.Name); // Specifies the new property name
    				var dtPropPrimitiveType = PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.DateTime); // Specifies the new property type
    				var prop = EdmProperty.CreatePrimitive(dtPropName, dtPropPrimitiveType); // Creates our new EdmProperty
    				extraProperties.Add(prop);
    			}
    		}
    
            foreach (var edmProperty in simpleProperties)
            {
    #>
        <#=		codeStringGenerator.Property(edmProperty)#>
    <#
            }
    		
            foreach (var edmProperty in extraProperties) // Loops through all the new properties that we've added to the extraProperties list
            {
    			// Writes the property to the entity code file
    #>
        <#=		codeStringGenerator.Property(edmProperty)#>
    <#
            }
        }
