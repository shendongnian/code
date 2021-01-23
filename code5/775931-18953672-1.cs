	var s1 = "1234";
	var s2 = "5678";
	var carry = false;
	var result = String.Empty;
	
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
