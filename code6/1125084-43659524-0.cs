    	var currentSpecificId = "123";
	var DataContext = this;
	var setProps = DataContext
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => 
				{
					return x.PropertyType.IsGenericType 
                    //todo better check
                    &&  x.PropertyType.Name.StartsWith("DbSet");
				})
				.ToArray();
				
			
                foreach (var setProperty in setProps)
                {
                    var entityType = setProperty.PropertyType.GetGenericArguments().First();
                    var set = DataContext.Set(entityType);
                    if (typeof (IHaveSpecificIdNo).IsAssignableFrom(entityType))
                    {
                        var items = ((IQueryable<IHaveSpecificIdNo>)set)
										.Where(x => x.SpecificIdNo == currentSpecificId).ToArray();
						if(items.Length == 0)
						{
							continue;
						}
						//do something
                    }
                }
