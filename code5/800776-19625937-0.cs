	static string itoa(int n)
	{
		char[] result = new char[11]; // 11 = "-2147483648".Length
		int index = result.Length;
		bool sign = n < 0;
		do
		{
			int digit = n % 10;
			if(sign)
			{
				digit = -digit;
			}
			result[--index] = (char)('0' + digit);
			n /= 10;
		}
		while(n != 0);
		if(sign)
		{
			result[--index] = '-';
		}
		return new string(result, index, result.Length - index);
	}
