        do {
	    if (iBinaryNum1 == 1 || iBinaryNum1 == 0)
        {
            Console.WriteLine("The binary value entered for integer 1 is correct");
        }
        else
        {
            Console.WriteLine("The binary value entered for integer 1 is incorrect");
            Console.WriteLine("Please Re-enter this value");
            iBinaryNum1 = Convert.ToInt32(Console.ReadLine());
        }
	} while (iBinaryNum1 ! = 999);
