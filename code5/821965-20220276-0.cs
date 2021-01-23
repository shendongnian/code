    void Main()
    {
	XElement FILE1 = XElement.Parse(
	@"<Root>
	    <Players>
	        <Player><ClientId>1</ClientId><FirstName>Bob</FirstName><LastName>Smith</LastName></Player>
	        <Player><ClientId>2</ClientId><FirstName>John</FirstName><LastName>Smith</LastName></Player>
	    </Players>
	</Root>");
	    XElement FILE2 = XElement.Parse(
	@"<Root>
	    <Players>
	        <Player><ClientId>2</ClientId><FirstName>Bob</FirstName><LastName>Smith</LastName></Player>
	        <Player><ClientId>3</ClientId><FirstName>Mike</FirstName><LastName>Smith</LastName></Player>
	    </Players>
	</Root>");
	
	var orders = from file1 in FILE1.Descendants("Players").Elements("Player")
	                    select new Player(Int32.Parse(file1.Element("ClientId").Value), file1.Element("FirstName").Value, file1.Element("LastName").Value);
	
	var orders2 = from file2 in FILE2.Descendants("Players").Elements("Player")
	                    select new Player(Int32.Parse(file2.Element("ClientId").Value), file2.Element("FirstName").Value, file2.Element("LastName").Value);
	
	//orders.Dump();
	//orders2.Dump();
	
	var exists = orders2.Intersect(orders, new LambdaEqualityComparer<Player>((i, j) => i.FirstName == j.FirstName && i.LastName == j.LastName));
	// or
	//var exists = orders2.Intersect(orders, new LambdaEqualityComparer<Player>((i, j) => i.ClientId == j.ClientId));
	exists.Dump();
	var notExists = orders2.Except(orders, new LambdaEqualityComparer<Player>((i, j) => i.FirstName == j.FirstName && i.LastName == j.LastName));
	// or
	//var notExists = orders2.Except(orders, new LambdaEqualityComparer<Player>((i, j) => i.ClientId == j.ClientId));
	notExists.Dump();
    }
    public class Player
    {
	public int ClientId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	
	public Player(int clientId, string firstName, string lastName)
	{
		ClientId = clientId;
		FirstName = firstName;
		LastName = lastName;
	}
    }
    public class LambdaEqualityComparer<T> : IEqualityComparer<T>
    {
	private Func<T, T, bool> EqualityComparer { get; set; }
	
	public LambdaEqualityComparer(Func<T, T, bool> equalityComparer)
	{
		EqualityComparer = equalityComparer;
	}
	
	public bool Equals(T x, T y)
	{
		return EqualityComparer(x, y);
	}
	
	public int GetHashCode(T obj)
	{
		// If the hash codes are different, then Equals never gets called. Make sure Equals is always called by making sure the hash codes are always the same.
		// (Underneath, the .NET code is using a set and the not (!) of a Find method to determine if the set doesn't already contain the item and should be added.
		// Find is not bothering to call Equals unless it finds a hash code that matches.)
		//return obj.GetHashCode();
		return 0;
	}
    }
