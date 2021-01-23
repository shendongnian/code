	class Program {
	
		delegate string MyDelegate();
		
		static string Do() {
			return "DO!";
		}
		
		static void Main() {
			MyDelegate d = new MyDelegate(Do);
			
			Console.WriteLine(d());		// Prints: DO!
		}
	}
	
