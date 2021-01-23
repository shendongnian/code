    var str = new[] { 
    	"HAMAN   409991     ",
    	"HAMAN  409991",
    	"HAMAN   509991"
    };
    
    foreach (var s in str)
    {
    	var result = s.Trim()
                      .Split(new[] {"   "}, StringSplitOptions.RemoveEmptyEntries)
                      .Select(a => a.Trim())
                      .ToList();
    	
    	if (result.Count != 2 || !result[1].StartsWith("4"))
    		continue;
    		
    	Console.WriteLine("{0}, {1}", result[0], result[1]);
    }
