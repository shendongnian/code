       static bool IsAnagram(string s1, string s2)
        {
    	    var lst1  = s1.AsEnumerable(); 
    		var lst2 = s2.AsEnumerable(); 
            
    		return lst1.SequenceEqual(lst2);
        }
