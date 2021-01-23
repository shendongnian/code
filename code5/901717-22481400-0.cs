  	public static void Main()
	{
		RefType r1 = new RefType();
		RefType r2 = r1;
		
		r1.Sprop = "hi there";
		
		Console.WriteLine(r2.Sprop);
	}
	
	public class RefType
	{
		public string Sprop { get; set; }
  	}
