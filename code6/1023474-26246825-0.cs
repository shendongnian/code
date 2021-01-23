	[Table("Employees")]
	public class Employee
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
	}
