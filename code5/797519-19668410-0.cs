    public T DeepCopy<S, T>(S source) where T : new()
    {
    	var sourceProperties = typeof(S).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    	T target = new T();
    	
    	foreach (var sourceProperty in sourceProperties)
    	{
    		var property = typeof(T).GetProperty(sourceProperty.Name);
    		
    		if (property.PropertyType.IsPrimitive || 
    			property.PropertyType == typeof(string) || 
    			(property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
    		{
    			object value = sourceProperty.GetValue(source);
    			
    			property.SetValue(target, value);
    		}
    		else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
    		{
    			var sourceList = (IEnumerable)sourceProperty.GetValue(source);
    			
    			if (sourceList != null)
    			{
    				var deepCopy = this.GetType().GetMethod("DeepCopy").MakeGenericMethod(sourceProperty.PropertyType.GenericTypeArguments[0], property.PropertyType.GenericTypeArguments[0]);
    				var ctor = property.PropertyType.GetConstructor(Type.EmptyTypes);
    				
    				IList targetList = (IList) ctor.Invoke(null);
    				
    				foreach (var element in sourceList)
    				{
    					targetList.Add(deepCopy.Invoke(this, new object[] { element } ));
    				}
    				
    				property.SetValue(target, targetList);
    			}
    		}
    		else
    		{
    			var value = sourceProperty.GetValue(source);
    			
    			if (value != null)
    			{
    				var deepCopy = this.GetType().GetMethod("DeepCopy").MakeGenericMethod(sourceProperty.PropertyType, property.PropertyType);
    								
    				property.SetValue(target, deepCopy.Invoke(this, new object[] { value }));
    			}
    		}
    	}
    	
    	return target;
    }
