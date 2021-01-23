            var myType = TypeBuilderUtil.BuildDynamicType();
            var myObject = Activator.CreateInstance( myType );
            // Set the value
            var propertyInfo = myObject.GetType().GetProperty( "Property1", BindingFlags.Instance | BindingFlags.Public );
            propertyInfo.SetValue( myObject, "PropertyValue", null );
