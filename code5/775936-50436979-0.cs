	string Add(string s1, string s2)
	{
		bool carry = false;
		string result = string.Empty;
		if(s1[0] != '-' && s2[0] != '-')
		{
			if (s1.Length < s2.Length)
				s1 = s1.PadLeft(s2.Length, '0');
			if(s2.Length < s1.Length)
				s2 = s2.PadLeft(s1.Length, '0');
			for(int i = s1.Length-1; i >= 0; i--)
			{
				var augend = Convert.ToInt64(s1.Substring(i,1));
				var addend = Convert.ToInt64(s2.Substring(i,1));
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
		}
		else if(s1[0] == '-' || s2[0] == '-')
		{
			long sum = 0;
			if(s2[0] == '-')
			{
				//Removing negative sign
				char[] MyChar = {'-'};
				string NewString = s2.TrimStart(MyChar);
				s2 = NewString;
				if(s2.Length < s1.Length)
					s2 = s2.PadLeft(s1.Length, '0');
				for (int i = s1.Length - 1; i >= 0; i--)
				{
					var augend = Convert.ToInt64(s1.Substring(i,1));
					var addend = Convert.ToInt64(s2.Substring(i,1));
					if(augend >= addend)
					{
						sum = augend - addend;
					}
					else 
					{
						int temp = i - 1;
						long numberNext = Convert.ToInt64(s1.Substring(temp,1));
						//if number before is 0
						while(numberNext == 0)
						{
							temp--;
							numberNext = Convert.ToInt64(s1.Substring(temp,1));
						}
						//taking one from the neighbor number
						int a = int.Parse(s1[temp].ToString());
						a--;
						StringBuilder tempString = new StringBuilder(s1);
						string aString = a.ToString();
						tempString[temp] = Convert.ToChar(aString);
						s1 = tempString.ToString();	
						while(temp < i)
						{
							temp++;
							StringBuilder copyS1 = new StringBuilder(s1);
							string nine = "9"; 
							tempString[temp] = Convert.ToChar(nine);
							s1 = tempString.ToString();
						}
						augend += 10;
						sum = augend - addend;
					}
					result = sum.ToString() + result;
				}
				//Removing the zero infront of the answer
				char[] zeroChar = {'0'};
				string tempResult = result.TrimStart(zeroChar);
				result = tempResult;
			}
		}
		return result;
	}
	string Multiply(string s1, string s2)
	{
		string result = string.Empty;
		//For multipication
		bool Negative = false;
		if(s1[0] == '-' && s2[0] == '-')
			Negative = false;
		else if(s1[0] == '-' || s2[0] == '-')
			Negative = true;
		char[] minusChar = {'-'};
		string NewString;
		NewString = s2.TrimStart(minusChar);
		s2 = NewString;
		NewString = s1.TrimStart(minusChar);
		s1 = NewString;
		List<string> resultList = new List<string>();
		for(int i = s2.Length - 1; i >= 0; i--)
		{
			string multiplycation = string.Empty;
			for (int j = s1.Length - 1; j >= 0; j--)
			{
				var augend = Convert.ToInt64(s1.Substring(j,1));
				var addend = Convert.ToInt64(s2.Substring(i,1));
				long multiply = augend * addend;
				// print(multiply); 
				multiplycation = multiply.ToString() + multiplycation;
			}
			//Adding zero at the end of the multiplication
			for (int k =  s2.Length - 1 - i; k > 0; k--)
			{
				multiplycation += "0";
			}
			resultList.Add(multiplycation);
		}
			
		for (int i = 1; i < resultList.Count; i++)
		{
			resultList[0] = Add(resultList[0],resultList[i]);
		}
		
		//Finally assigning if negative negative sign in front of the number
		if(Negative)
			result = resultList[0].Insert(0,"-");
		else
			result = resultList[0];
		return result;
	}
	string Divide(string dividend, string divisor)
	{
		string result = string.Empty;
		int remainder = 0;
		int intNumberstoGet = divisor.Length;
		int currentInt = 0;
		int dividing = int.Parse(dividend.Substring(currentInt,intNumberstoGet));
		
		int intDivisor = int.Parse(divisor);
		while(currentInt < dividend.Length)
		{
			if(dividing == 0)
			{
				currentInt++;
				result += "0";
			}
			else
			{
				while(dividing < intDivisor)
				{
					intNumberstoGet++;
					dividing = int.Parse(dividend.Substring(currentInt,intNumberstoGet));
				}
			
				if (dividing > 0)
				{	
					remainder = dividing % intDivisor;
					result += ((dividing - remainder) / intDivisor).ToString();
					intNumberstoGet = 1;
					
					if(currentInt < dividend.Length - 2)
						currentInt += 2;
					else
						currentInt++;
						
					if(currentInt != dividend.Length)
					{
						dividing = int.Parse(dividend.Substring(currentInt,intNumberstoGet));
						remainder *= 10;
						dividing += remainder;
					}
				}
			}
		}
		return result;
	}
