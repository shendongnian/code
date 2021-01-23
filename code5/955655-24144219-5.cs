    class Person
    {
    	[StringNotNullOrEmpty]
    	string FirstName { get; set; }
    
    	[Range(Min = 0, Max = 100)]
    	int Age {get; set; }
    }
