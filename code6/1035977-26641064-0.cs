    using System;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			var email = "employee1@2 r&a*d.m32@@company98 ';99..com";
			
			var result = GetValidEmail(email);
			
			Console.WriteLine(result);
		}
		
	
		public static string GetValidEmail(string email)
		{
		  var result = email.ToLower();
		 
          // Does it contain everything we need?
		  if (email.StartsWith("employee")
			  && email.EndsWith(".com")
			  && email.Contains("@company"))
		  {
            // remove beginning and end.
			result = result.Substring(8, result.Length - 13);
            // remove @company
			var split = result.Split(new string[] { "@company" },
			  StringSplitOptions.RemoveEmptyEntries);
	
            // validate we have more than two (you may not need this)
			if (split.Length != 2)
			{
			  throw new ArgumentException("Invalid Email.");
			}
	 
            // recreate valid email
			result = "employee"
			  + new string (split[0].Where(c => char.IsLetterOrDigit(c)).ToArray())
			  + "@company"
			  + new string (split[1].Where(c => char.IsLetterOrDigit(c)).ToArray())
			  + ".com";
	   
		  }
		  else
		  {
			throw new ArgumentException("Invalid Email.");
		  }
	
		  return result;
		}
	}
