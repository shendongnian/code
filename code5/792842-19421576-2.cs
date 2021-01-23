    public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Salary { get; set; }
		public User()
		{
			
		}
		public User(int id, string name, int salary)
		{
			Id = id;
			Name = name;
			Salary = salary;
		}
	}
