    Person person = new Person {
    	ID = "1",
    	FirstName = "First",
    	LastName = "Last",
    	Age = 31			
    };
    
    Console.WriteLine(person.GetStringProperty("FirstName"));
    Console.WriteLine(person.GetProperty<int>("Age"));
