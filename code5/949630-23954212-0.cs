    void Main()
    {
    	Console.WriteLine(Get<int>("System.Int32").ToString());
    	Console.WriteLine(Get<string>("System.String").ToString());
    	Console.WriteLine(Get<double>().ToString());
    	Console.WriteLine(Get<long>().ToString());
    }
    
    public Type TypeResolver(string type)
    {
    	return Type.GetType(type);
    }
    
    public IEnumerable<T> Get<T>(string typeName)
    {	
    	var type = TypeResolver(typeName);
    	var entityStore = new EntityStore();
    	return entityStore.GetType().GetMethod("GetAll").MakeGenericMethod(type).Invoke(entityStore, null) as IEnumerable<T>;
    }
    
    public IEnumerable<T> Get<T>()
    {
    	var entityStore = new EntityStore();
    	return entityStore.GetType().GetMethod("GetAll").MakeGenericMethod(typeof(T)).Invoke(entityStore, null) as IEnumerable<T>;
    }
    
    public class EntityStore
    {
    	public IEnumerable<T> GetAll<T>()
    	{
    		return new List<T>();
    	}
    }
