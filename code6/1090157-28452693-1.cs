    public static void test()
    {
    	Group group =new Group();
    	group.name= "Friends";
    
    	Person p = new Person("John",30);
    	Person p2 = new Person("Rute",25);
    	Person p3= new Person("Richard",17);
    
    	group.Persons.Add(p);
    	group.Persons.Add(p2);
    	group.Persons.Add(p3);
    
    	foreach(Person person in group.Persons)
    	{
    		Console.WriteLine("{0} is {1} years old. He is in group {2}.",person.name,person.age,group.name);
    	}
    }
