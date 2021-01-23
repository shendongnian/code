    string s1 = "My Name is Vishal.";
    string s2 = "My Name is not Vishal.";
    var input = s1;
    var list = input .Split(" ".ToCharArray()).ToList();
    StringBuilder sb = new StringBuilder();
    
    while (list.Any()) {
    	var bits = list.Take(2);
    	sb.Append(bits.First ());
    	if (bits.Count() >1) {
    		sb.AppendLine(" " + bits.Last());
    		list.RemoveRange(0,2);
    	}
    	else
    		list.RemoveAt(0);
    }
    var result = sb.ToString(); 
   
