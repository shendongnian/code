	public class Customers
	{
		public List<Person> Persons { get; set; }
		public List<Organization> Organizations { get; set; }
		
		public Customers()
		{
			Persons = new List<Person>();
			Organizations = new List<Organization>();
		}
		
		public Customers(IEnumerable<Person> persons,
                         IEnumerable<Organization> organizations)
			: this()
		{
			Persons.AddRange(persons);
			Organizations.AddRange(organizations);
		}
		
		public IEnumerable<string> Keys
		{
			return Persons.Select(p => p.CustomId)
						  .Concat(Organizations.Select(o => o.CustomId));
		}
	}
