    for (int loopCount = 0; loopCount < 9; loopCount++)
    {
       Console.WriteLine("Employee #" + (loopCount + 1) + " first name: ");
       
       fullName[loopCount, 0] = Console.ReadLine().ToLower();
       while(fullName[loopCount, 0].Length == 0)
       {
           Console.WriteLine("Bad Input, Retry");
           fullName[loopCount, 0] = Console.ReadLine().ToLower();
       }
    }
