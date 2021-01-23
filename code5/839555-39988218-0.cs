	void Main()
	{
		var elements = new Base[]{
			new Base(){	 Name = "Base instance"},
			new D1(){	 Name = "D1 instance"},
			new D2(){	 Name = "D2 instance"}
		};
		
		foreach(Base x in elements){
			x.Process();
		}
	}
	
	public class Base{
		public string Name;
	}
	public class D1 : Base {}
	public class D2 : Base {}
	
	public static class Exts{
	
		public static void Process(this Base obj){
			if(obj is Base) ProcessBase(obj);
			else Process((dynamic) obj);
		}
		
		private static void ProcessBase(Base obj){
			Console.WriteLine("Base: {0}", obj.Name);
		}
		
		public static void Process(this D1 obj){
			Console.WriteLine("D1: {0}", obj.Name);
		}
		
		public static void Process(this D2 obj){
			Console.WriteLine("D2: {0}", obj.Name);
		}
	}
