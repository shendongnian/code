    public class Brand
    {
        public int Number { get; set; }
        public string Name { get; set; }
    	
    	public override string ToString()
    	{
    	    return Name;
    	}
    }
    void Method()
    {
        var brands = new List<Brand>()
        {
            new Brand { Number = 1, Name = "a" },
            new Brand { Number = 2, Name = "b" }
        };
        // outputs: a,b
        Console.WriteLine(string.Join(",", brands));
    }
