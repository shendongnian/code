    public static PropertyInfo[] GetNavigationProperties<TEntity>(DbContext context)
        	where TEntity: class
		{
		    var objContext = ((IObjectContextAdapter)context).ObjectContext;
		    var elementType = objContext.CreateObjectSet<TEntity>().EntitySet.ElementType;
		    return elementType.NavigationProperties.Select(prop => typeof(TEntity).GetProperty(prop.Name)).ToArray();
		}
