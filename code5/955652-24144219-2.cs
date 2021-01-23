    class Person
    {
    	[StringNotNullOrEmpty]
    	FirstName { get; set; }
    
    	[Range(0,100)]
    	Age {get; set; }
    }
