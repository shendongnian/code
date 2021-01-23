    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
	    public static void Main()
	    {
		    string raw = @""; //Paste text here, new lines and all
		    string[] lines = raw.Split(new string[] { Environment.NewLine },  StringSplitOptions.None); 
		    string name = "";
		    string obrId = "";
		    foreach (string line in lines)
		    {
			    if (line.Contains("PID"))
			    {
			        name = Regex.Match(line,@"^PID([\|]*[^\|]*){3}[\|]*([^\|]*)").Groups[2].Value;
			    }
			    else if (line.Contains("OBR"))
			    {
			        obrId = Regex.Match(line,@"OBR\|[\d]*\|(\d*)\|").Groups[1].Value;
			    }
		    }
		    Console.WriteLine(name);
		    Console.WriteLine(obrId);
	    }
    }
