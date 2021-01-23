    using System;
    using System.Globalization;
    class theclass
    {
	static void Main()
	{
		string str1 = "war and peace";
		string str2 = "mr. popper's penguins";
		Console.WriteLine(Titlizing(str1));
		Console.WriteLine(" ");
		Console.WriteLine(Titlizing(str2));
		
	
	}
	
	public static string Titlizing( string toTitle )
	{
		string[] dawords = toTitle.Split(' ');
		string output = "";
		TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
		
		foreach (string s in dawords)
		{
			
			switch(s)
			{
				case "and":
					output += ' '+ s;
					break;
				case "or":
					output += ' '+ s;			
					break;
				case "of":
					output += ' '+ s;
					break;
				default:
				{
					output += ' '+myTI.ToTitleCase(s);
					break;
				}
			}
		}
		return output;
	}
    }
