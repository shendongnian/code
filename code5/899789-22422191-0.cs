    int hitcounter = 0;
    while (!GameOver)
	{ 
	    Console.Write("Answer: ");
        string answer = Console.ReadLine();
		
		if (answer.ToLower() == "hint")
		{
			if (hitcounter < 10)
			{
			   hitcounter++;
			   //write the hints
			}
			else
			{
				//write you reached the maximum of the hints
			}
		}
	}
