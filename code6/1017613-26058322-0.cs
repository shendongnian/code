    void Main()
    {
    	var result = new string[] {"1","John","2","Doe","3","Jack","4","Daniel","5","Foo","6","Bar",};
    	List<Person> personList = new List<Person>();
    	
    	for(int i = 0; i < result.Length; i+=2)
    	{
            //use TryParse()!. 
    		personList.Add(new Person() {Id = int.Parse(result[i]), Name = result[i+1]});
    	}
    	
    	personList.Dump();
    }
    
    public class Person
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
