    public class EntityResolver<TEntity> : IValueResolver where TEntity : class, IEntity, new()
    {
    	public ResolutionResult Resolve(ResolutionResult source)
    	{
    		return source.New(ResolveObject(source));
    	}
    
    	private object ResolveObject(ResolutionResult source)
    	{
    		if (!source.Context.Options.Items.ContainsKey("Services")) return null;
    
    		var services = (List<object>)source.Context.Options.Items["Services"];
    		var item = services.FirstOrDefault(s => s is IBaseService<TEntity>);
    		if (item == null) return null;
    
    		var id = (long)source.Value;
    		if (id <= 0) return null;
    
    		var service = (IBaseService<TEntity>)item;
    		return service.GetById(id);
    	}
    }
