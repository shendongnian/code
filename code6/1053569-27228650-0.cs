    class Student
    {
        public string First { get; set; }
        public string Last {get; set;}
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    	public int[] Scores { get; set; }
    }
    
    class SomethingComplex
    {
    	public void AComplexThing_1(string first, string last, int id, string street, string city, int[] scores)
    	{
    		// do something
    	}
    	
    	public void AComplexThing_2(Student student)
    	{
    	}
    }
