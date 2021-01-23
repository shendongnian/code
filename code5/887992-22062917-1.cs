	// library
	public interface IA
	{
		List<string> ListOfEmployees();
	}
	
	public class ABase : IA
	{
		public virtual List<string> ListOfEmployees() {}
	}
	
	public static class Repository
	{
		private static IA _a;
		
		public static IA A
		{
			get { return _a = _a ?? new ABase(); }
			set { _a = value; }
		}
	}
	// in your app
	class Properties : ABase
	{
		public override List<string> ListOfEmployees() { /* ... */ }
	}
	Repository.A = new Properties();
