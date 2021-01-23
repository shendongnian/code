	int[] A = { 3, 6, 4, 9, 10, 1, 2, 8 };
	int myNumber;
	int length = A.Length;
	Console.WriteLine("enter your number");
	myNumber = Convert.ToInt32(Console.ReadLine());
    // ADDED
	bool found = false;
	
	for (int i = 0; i < length; i++)
	{
		if (myNumber == A[i])
		{
			found = true; // ADDED
			Console.WriteLine("the numer" + myNumber + "is present in the array at the index" + " " + i); // Fixed A[i] -> i
			break;
		}
	}
    // ADDED
	if (!found)
	{
		Console.WriteLine("the number you entered are not found");
	}
	Console.ReadKey();
