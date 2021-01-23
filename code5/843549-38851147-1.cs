        private static List<PropertyInfo> GetNavigationProperties(Type t)
    	{
    
    		var navigationProperties = new List<PropertyInfo>();
    
    		if (t.BaseType != null && t.Namespace == "System.Data.Entity.DynamicProxies") {
    			t = t.BaseType;
    		}
    
    		string fkName = t.Name + "Id";
    
    		var allProps = new List<PropertyInfo>();
    
    		foreach (PropertyInfo p in t.GetProperties()) {
    			if (p.PropertyType.IsGenericType) {
    				dynamic GenericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
    				if (GenericTypeDefinition == typeof(ObservableCollection<>) || GenericTypeDefinition == typeof(ICollection<>) || GenericTypeDefinition == typeof(IEnumerable<>)) {
    					allProps.Add(p);
    				}
    			}
    		}
        
    		foreach (PropertyInfo prop in allProps) {
    			// This checks if the other type has a FK Property of this Type.
    			var type = prop.PropertyType.GetGenericArguments().First();
    
    			bool HasOneProperty = type.GetProperties().Any(x => x.Name.Equals(fkName, StringComparison.OrdinalIgnoreCase));
    
    			if (HasOneProperty) {
    				navigationProperties.Add(prop);
    			}
    
    		}
    
    		return navigationProperties;
    
    	}
