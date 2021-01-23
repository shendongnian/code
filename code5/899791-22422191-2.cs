    int hitcounter = 0;
    int lastHint = -1;
    while (!GameOver)
	{ 
	    Console.Write("Answer: ");
        string answer = Console.ReadLine();
		
		if (answer.ToLower() == "hint")
		{
			if (hitcounter < 10)
			{  
                           //preveintg double hint. something like that. 
                           //you can use later array or list if you need more hint
                           int hint = generaterandomhints();
                           while (hint == lastHint)
                           { 
                               hint = generaterandomhints();
                           }
                           
			   hitcounter++;
			   //write the hints
			}
			else
			{
				//write you reached the maximum of the hints
			}
		}
	}
