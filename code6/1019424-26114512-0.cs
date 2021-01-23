    void Main()
    {
    	var AllCodes = new List<Code>() 
    	{
    		new Code() {Id = 1, Description="Foo1"},
    		new Code() {Id = 2, Description="Bar2"},
    		new Code() {Id = 3, Description="Foo3"},
    		new Code() {Id = 4, Description="Bar4"}
    	};
    	
    	var relatedCodes = new Code[2] 
    	{
    		new Code() {Id = 2, Description="Bar2"},
    		new Code() {Id = 4, Description="Bar4"}
    	};
    	
    	var joinedCodes = from ac in AllCodes
    					  join rc in relatedCodes on ac.Id equals rc.Id
    					  select ac;
    	joinedCodes.Dump();
    }
    
    // Define other methods and classes here
    public class Code{
        public int Id { get; set; }
    	public string Description { get; set; }
    }
