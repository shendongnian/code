      {
    	string a = "a"; // 1
    	string b = "b"; // 2
    
    	int c = string.Compare(a, b);
    	Console.WriteLine(c);
    
    	c = string.CompareOrdinal(b, a);
    	Console.WriteLine(c);
    
    	c = a.CompareTo(b);
    	Console.WriteLine(c);
    
    	c = b.CompareTo(a);
    	Console.WriteLine(c);
        }
     
