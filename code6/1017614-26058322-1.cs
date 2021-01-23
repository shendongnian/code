    void Main()
    {
    	var result = new string[] {"1","John Doe","2","Joes Group","3","Jack Daniel","4","Jacks Group","5","Foo Bar","6","FooBar Group",};
    	List<Person> personList = new List<Person>();
    	List<Group> groupList = new List<Group>();
    	
    	for(int i = 0; i < result.Length; i+=2) 
    	{
    		//check if group does not already exist
    		groupList.Add(new Group() {Name = result[i+1]});
    	}
    	
    	for(int i = 0; i < result.Length; i+=2)
    	{
    	    //check if person exists.
    		//if person only add group to person personList.Where(x => x.Name ==result[i+1])....
    		personList.Add(new Person() { Id = int.Parse(result[i]), 
    									  Name = result[i+1],
    									  Groups = new List<Group>()
    									  {
    									  	new Group() {Name = result[i+3]} 
    									  }
    									});
    		i = i+2;	
    	}
    	
    	personList.Dump();
    }
    
    public class Person
    {
    	public Person()
    	{
    		Groups = new List<Group>();
    	}
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public List<Group> Groups { get; set; }
    	
    }
    
    public class Group
    {
    	public string Name { get; set; }
    }
    // Define other methods and classes here
