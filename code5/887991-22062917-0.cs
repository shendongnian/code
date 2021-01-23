	// library
	public interface IA
	{
		List<string> ListOfEmployees();
	}
	public static class Repository
	{
		public static IA A { get; set; }
	}
	// in your app
	class Properties : IA
	{
		public List<string> ListOfEmployees() { /* ... */ }
	}
	Repository.A = new Properties();
