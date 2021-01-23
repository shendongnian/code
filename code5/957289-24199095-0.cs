    void Main()
    {
    	List<CustomObject> List1 = new List<CustomObject>() 
    	{
    		new CustomObject() {UserName ="1", IsUserEmployed = true, IsUserValid = false},
    		new CustomObject() {UserName ="2", IsUserEmployed = true, IsUserValid = false},
    		new CustomObject() {UserName ="3", IsUserEmployed = true, IsUserValid = false},
    		new CustomObject() {UserName ="4", IsUserEmployed = true, IsUserValid = false}
    	};
    	List<CustomObject> List2 = new List<CustomObject>() 
    	{
    		new CustomObject() {UserName ="2", IsUserEmployed = true, IsUserValid = false},
    		new CustomObject() {UserName ="3", IsUserEmployed = true, IsUserValid = false},
    		
    	};
    	
    	IEqualityComparer<CustomObject> CustomComparer = new CustomObjectEqualityComparer<CustomObject>();
    	
    	var xor = List1.Except(List2, CustomComparer).ToList().Dump();
    
        
    }
    public class CustomObject 
    {
    	public string UserName { get; set; }
    	public bool IsUserEmployed { get; set; }
    	public bool IsUserValid { get; set; }
    }
    
    
    public class CustomObjectEqualityComparer<T> : IEqualityComparer<CustomObject>
    {
    	public bool Equals(CustomObject t1, CustomObject t2)
    	{
    		if(t1.IsUserEmployed == t2.IsUserEmployed &&
    		   t1.IsUserValid ==t2.IsUserValid &&
    		   t1.UserName == t2.UserName)
    	   {
    	   		return true;
    	   }
    				
    		return false;
    	}
    	
    	public int GetHashCode(CustomObject _obj)
    	{
    		return _obj.IsUserEmployed.GetHashCode() + _obj.IsUserEmployed.GetHashCode() + _obj.IsUserValid.GetHashCode();
    	}
    }
    public static class IEnumerableExtensions
    {
      public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
      {
        foreach (T item in source)
          action(item);
      }
    }
