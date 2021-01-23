	public void SanitizeObject(object some)
	{
		// We get properties which are of reference types because we don't want to iterate value types (do you want to sanitize an integer...?)
		foreach (PropertyInfo property in some.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(prop => !prop.PropertyType.IsValueType)
		{
			if (property.PropertyType == typeof (string))
			{
			// Do stuff to sanitize the string
			}
			else
			{
				// Get properties declared in the concrete class (skip inherited members)
				var properties = property.DeclaringType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
				
                // Does the property type has properties?
				if (properties != null && properties.Length > 0)
				{
					// This gets the custom object and starts a recursion to sanitize its string properties if the object have string properties, of course...
					SanitizeObject(property.GetValue(some));
				}
			}
		}
	}
