	public class Program
	{
		
		public static void Main()
		{
			string testString1 = "{[balanced(parenthesis)]}";
			string testString2 = "(test)[wrong bracket type)";
			string testString3 = "(test)[Mismatched]((sdff)";
			
			bool isValid1 = ValidateString(testString1);
			bool isValid2 = ValidateString(testString2);
			bool isValid3 = ValidateString(testString3);
			
			if (isValid1)
				Console.WriteLine("TestString1 is balanced correctly!");
			else Console.WriteLine("TestString1 is NOT balanced properly!");
			if (isValid2)
				Console.WriteLine("TestString2 is balanced correctly!");
			else Console.WriteLine("TestString2 is NOT balanced properly!");
			
			if (isValid3)
				Console.WriteLine("TestString3 is balanced correctly!");
			else Console.WriteLine("TestString3 is NOT balanced properly!");
		}
		
		public static bool ValidateString(string testString)
		{
			int p1 = 0;
			int p2 = 0;
			int p3 = 0;
			
			var lastOpener = new Stack<char>();
			
			foreach (char c in testString)
			{
				if (c == '(') {
					p1++;
					lastOpener.Push(c);
				}
				if (c == '[') {
					p2++;
					lastOpener.Push(c);
				}
				if (c == '{') {
					p3++;
					lastOpener.Push(c);
				}
                try {				
    				if (c == ')' && lastOpener.Pop() == '(')
	    				p1--;
		    		if (c == ']' && lastOpener.Pop() == '[')
			    		p2--;
				    if (c == '}' && lastOpener.Pop() == '{')
    					p3--;
                } catch { return false; }
	 		}
			
			if (p1 != 0 || p2 != 0 || p3 != 0)
				return false;
			return true;
		}
	}
