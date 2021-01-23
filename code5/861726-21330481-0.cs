    void Main()
    {
    	var students = new List<student>() 
    	{
    	  new student("Alphonso", "Zander"),
    	  new student("Berta", "Zander"),
    	  new student("Giacomo", "Zander"),
    	  new student("Marc", "Lastly"),
    	  new student("God", "Allmighty")
    	};
    	
    	var sortedStudents = students.OrderBy(s => s.lastName).ThenBy(s => s.firstName).Dump();
    }
    
    // Define other methods and classes here
    class student
    {
    	public student(string fname, string lname)
    	{
    	 this.firstName = fname; this.lastName = lname;
    	}
      public string firstName { get; set; }
      public string lastName { get; set; }
    }
