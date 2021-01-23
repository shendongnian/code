    class Group
    {
    	public string name { get; set; }
    	public List<Person> Persons = new List<Person>();
    }
    class Person
    {
    	public string name { get; set; }
    	public int age { get; set; }
    	public Person(string name, int age)
    	{
    		this.name = name;
    		this.age = age;
    	}
    }
