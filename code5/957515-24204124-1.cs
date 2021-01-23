	using System;
	using System.Linq;
	
						
	public class Program {
		public static void Main() {
					
			Console.WriteLine("LANE/CLEAN: {0}", Test("LANE", "CLEAN"));
			Console.WriteLine("AGED/CAGED: {0}", Test("AGED", "CAGED"));
			Console.WriteLine("AGED/RAGE: {0}", Test("AGED", "RAGE"));
			Console.WriteLine("CANCEL/CONCEAL: {0}", Test("CANCEL", "CONCEAL"));
			
		}
		
		public static bool Test(string s1, string s2) {	
			
			var sourceLetters = s1.ToCharArray().ToList();
			
			foreach (var letter in s2.ToCharArray())
				if (sourceLetters.Contains(letter))
					sourceLetters.Remove(letter);
				
			return !sourceLetters.Any();		
				
		}
	}
	
	// Results:
	//
	// LANE/CLEAN: True
	// AGED/CAGED: True
	// AGED/RAGE: False
	// CANCEL/CONCEAL: True
