	public class Cache<T> where T: Animal
	{
	    private static List<T> _animals = new List<T>();
	    public T GetCachedObj()
	    {
	    	return _animals.First();
	    }
	}
	var dogsCache = new Cache<Dog>();
	Dog dog = dogsCache.GetCachedObj();
	var catsCache = new Cache<Cat>();
	Cat cat = catsCache.GetCachedObj();
