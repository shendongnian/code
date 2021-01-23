       static bool IsAnagram(string s1, string s2)
        {
    	    var lst1  = s1.OrderBy(c => c); //will result in { 'A','H','I', 'M' }
    		var lst2 = s2.OrderBy(c => c); //will *also* result in { 'A','H','I', 'M' }
            
    		return lst1.SequenceEqual(lst2);
        }
