    Console.WriteLine("Enter your seat: ");
    string textToReplace = Console.ReadLine() ;
    boolean isFullyBooked = true;
    boolean isSeatTaken = true;
    for (int row = Arr.GetLowerBound(0); row <= Arr.GetUpperBound(0); ++row)
    {
    	for (int column = Arr.GetLowerBound(1); column <= Arr.GetUpperBound(1); ++column)
    		if (Arr[row, column].Contains( textToReplace))
			{
				Arr[row, column] = " X ";
				isSeatTaken = false;
			}
			if(!Arr[row, column].Contains(" X "))
			{
				isFullyBooked = false;
			}
		}
	}
	if(isFullyBooked)
	{
		Console.WriteLine("Fully Booked");
	}
	if(isSeatTaken)
	{
		Console.WriteLine("Already Taken");
	}
