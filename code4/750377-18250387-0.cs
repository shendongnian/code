    public List<dynamic> GetAnonymousList()
    {
       var list = new List<dynamic>()
    	{
    	   new { Foo = 123, Bar = "abc" },
    	   new { Foo = 456, Bar = "def" }
    	};
    	
    	return list;
    }
