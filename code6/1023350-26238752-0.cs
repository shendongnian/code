		var s = "Bob Williams;OW,Bob Green;PD,Frank Williams;OW,Andy Richards;BD,James Clack;PM,Dave Williams;OW";
		var r = new Regex("(;OW,|^OW,|;OW$)");
		if (r.IsMatch(s)) 
		{
			foreach (Match m in r.Matches(s)) 
			{
			    var rIdx = m.Index;
			    var pIdx = s.LastIndexOf(",",rIdx);
		        var person = s.Substring(pIdx + 1, rIdx - pIdx - 1);
		        Console.WriteLine(person);
			}
		}
		else 
		{
			Console.WriteLine("Role not found");
		}
