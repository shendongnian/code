		string user_input1 = "25.9cd";
		
	 	char[] arr = user_input1.ToCharArray();
		string num = "";
		string str = "";
		
		for(int i=0; i < arr.Length; i++)
		{
			if (char.IsNumber(arr[i]) || arr[i] == '.')
			{
				num += arr[i];
			}
			else {
			 str += arr[i];
			}
		}
		
		//you can cast num to an int, however..
		Console.WriteLine(num); //25.9
		Console.WriteLine(str); //cd	
