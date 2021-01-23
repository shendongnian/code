    void Main()
    {
    	var a = new List<int> { 1, 2 };
        var b = a.ToList();
        b[0] = 2;
        a.Dump();
        b.Dump();
    	
    	var c = new List<Person> { new Person { Age = 5 } };
        var d = c.ToList();
        d[0].Age = 10;
        c.Dump();
        d.Dump();
    }
    
    class Person
    {
        public int Age { get; set; }
    }
