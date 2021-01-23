	void Main()
	{
		var Emps = Emp.GetData();
	
		var q = (from d in (from e in Emps
				group e by e.DeptNo)
				select d.Take(2)).SelectMany(e=>e);
	
		q.Dump();
	}
	
    // Boring setup details
	class Emp
	{
		public int EmpNo {get; set;}
		public string  FirstName {get; set;}
		public string LastName {get; set;}
		public int DeptNo {get; set;}
		public int Salary {get; set;}
	
		public Emp(int no, string fn, string ln, int de, int sal)
		{
			this.EmpNo = no;
			this.FirstName = fn;
			this.LastName = ln;
			this.DeptNo = de;
			this.Salary = sal;
		} 
		
		static public Emp[] GetData()
		{
		return new Emp[] {
			new Emp (1,"Danny", "Rancher", 1, 16000),
			new Emp (2,"Test1", "Test1", 1, 16500),
			new Emp (3, "Test2", "Test2", 2, 10000),
			new Emp (4, "Test3", "Test3", 2, 21000),
			new Emp (5, "Test4", "Test4", 2, 17000),
			new Emp (6, "Test5", "Test5", 3, 5000),
			new Emp (7, "Test6", "Test6", 3, 45000),
			new Emp (8, "Test7", "Test7", 3, 27000),
			new Emp (9, "Test8", "Test8", 4, 23000),
			new Emp (10, "Test9", "Test9", 4, 22000),
			new Emp (11, "Test10", "Test10", 4, 10000),
			new Emp (12, "Test11", "Test11", 4, 50000)  
		};
		}
		
	}
