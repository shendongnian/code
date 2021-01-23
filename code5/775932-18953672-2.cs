    var s1 = "12345";
    var s2 = "5678";
    var carry = false;
    var result = String.Empty;
    
    if(s1.Length != s2.Length)
    {
    	var diff = Math.Abs(s1.Length - s2.Length);
    	
    	if(s1.Length < s2.Length)
    	{
    		s1 = String.Join("", Enumerable.Repeat("0", diff)) + s1;
    	}
    	else
    	{
    		s2 = String.Join("", Enumerable.Repeat("0", diff)) + s2;
    	}
    }
	
	for(int i = s1.Length-1;i >= 0; i--)
	{
		var augend = Convert.ToInt32(s1.Substring(i,1));
		var addend = Convert.ToInt32(s2.Substring(i,1));
		var sum = augend + addend;
		sum += (carry ? 1 : 0);
		carry = false;
		if(sum > 9)
		{
			carry = true;
			sum -= 10;
		}
		
		result = sum.ToString() + result;
	}
	
	if(carry)
	{
		result = "1" + result;
	}
	
	Console.WriteLine(result);
