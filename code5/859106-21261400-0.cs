    public class Foo : IFoo
    {
    	IDbAccess db;
    	
        // Pass the interface, do pass parameters to create it inside constructor
    	public Foo(IDbAccess db)
    	{
    		this.db = db; 
    	}
    	
    	public Dictionary<string,string> GetSomething(string xyz)
        {
            var result = new Dictionary<string,string>
            // ... Go to DB and return some key value pairs
            result.Add(db.MethodWhatever(xyz));
    		
            return result;
        }
    }
    
    [TestMethod()]
    public void GetSomething()
    {
    	var dbMock = new DatabaseMock(); // This implements IDbAccess
    	var target = new Foo(dbMock);
    
    	var expected = new Dictionary<string, string> 
    	{
    		{"blahKey","blahValue"}
    	};
    
    	// get something
    	var results = target.GetSomething("xyzstring");
    
    	// verify results
    	var actual = results.whatever;
    
    	CollectionAssert.AreEqual(expected,actual);
    }
