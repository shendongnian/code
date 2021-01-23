    public class User
    {
    	public string Name { get; set; }
    	public string Sex { get; set; }
    	public DateTime Birthday { get; set; }
    	public int? FilterId { get; set; }
    }
    public class LambdaCustomComparer<T> : IEqualityComparer<T>
    {
    	private readonly Func<T, T, bool> lambdaComparer;
    	private readonly Func<T, int> lambdaHash;
    
    	public LambdaCustomComparer(Func<T, T, bool> lambdaComparer, bool ignoreHashcode = true)
    	{
    		if (lambdaComparer == null)
    			throw new ArgumentNullException("lambdaComparer");
    
    		this.lambdaComparer = lambdaComparer;
    		
    		if (ignoreHashcode)
    			lambdaHash = obj => 0;
    		else
    			lambdaHash = EqualityComparer<T>.Default.GetHashCode;
    	}
    	public bool Equals(T x, T y)
    	{
    		return lambdaComparer(x, y);
    	}
    
    	public int GetHashCode(T obj)
    	{
    		return lambdaHash(obj);
    	}
    }
    var list = new List<User>
    {
    	new User() {Name = "Josh", Sex= "M", Birthday = DateTime.Now, FilterId = null},
    	new User() {Name = "John", Sex= "M", Birthday = DateTime.Now, FilterId = null},
    	new User() {Name = "Jane", Sex= "F", Birthday = DateTime.Now, FilterId = null},
    	new User() {Name = "Josh", Sex= "M", Birthday = DateTime.Now, FilterId = 1},
    	new User() {Name = "John", Sex= "M", Birthday = DateTime.Now, FilterId = null},
    };
    var comparer = new LambdaCustomComparer<User>((a, b) => a.Name == b.Name && a.Birthday.Date == b.Birthday.Date && a.Sex == b.Sex && a.FilterId == b.FilterId);
    var distinctList = list.GroupBy(user => user, comparer).ToDictionary(a => a.Key, b => b.ToArray());
