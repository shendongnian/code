    using System;
    using System.Linq;
    
    var items = new int[] {1,2,6,8,10,5,6,9,4,4,2,6,8,2,4,7,9,2,4};
    
    var result = items.GroupBy(x => {
    	//x between 1 to 3, and counting.
    	if (x >= 1 && x <= 3) return 1;
    	//x between 4 to 7, and counting.
    	if (x >= 4 && x <= 7) return 2;
    	//x between 8 and 10, and counted.
    	if (x >= 8 && x <= 10) return 3;
    	//else
    	return 4;
    }).ToDictionary(x => x.Key, x => x.Count());
    
    
    foreach (var kv in result)
    {
       Console.WriteLine("Key = {0}, Value = {1}", kv.Key, kv.Value);
    }
