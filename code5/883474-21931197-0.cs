    void Main()
    {
    	var a = new Entity[] {new Entity { name = "a"},new Entity { name = "b"}};
    	
    	Console.WriteLine(a.Take(1).Map<EntityDto>());
    }
    
    public class Entity
    {
    	public string name;
    }
    
    public class EntityDto
    {
    	public string dtoname;
    
    }
    
    public static class EntityExtensions
    {
    	public static IEnumerable<U> Map<T,U>(this IEnumerable<T> e) where T: Entity where U: EntityDto, new()
    	{
    		foreach(var a in e)
    		{
    			yield return new U() { dtoname = a.name };
    		}
    	}
    
    
    	public static IEnumerable<U> Map<U>(this IEnumerable<object> e)
    	{
    		var method = typeof(EntityExtensions).GetMethods(BindingFlags.Static | BindingFlags.Public)		
    		.Where(m => m.Name == "Map" && m.GetGenericArguments().Length == 2)
    		.Single();
    		method = method.MakeGenericMethod(e.GetType().GetGenericArguments()[0], typeof(U));
    		
    		return method.Invoke(null, new object[] { e}) as IEnumerable<U>;
    	}
    }
