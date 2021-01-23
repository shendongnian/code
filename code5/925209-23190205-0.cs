     while(true) 
     {
        Console.Write("Please enter your age ");
        string agestring = Console.ReadLine();
        int age;
        var array = ()
        if (Int32.TryParse(agestring, out age))
        {
            if (age >= 21)
            {
                Console.WriteLine("congrats, you can get drunk!");
            }
            else if (age < 21)
            {
                Console.WriteLine("Sorrrrrryyyyyyy =(");
            }
            //If you want the program to exit after a valid input, break to get out of loop
            break;
        }
        else if (age != ????)
        {
            Console.WriteLine("Sorry Thats not a valid input, Please enter a correct number.\n");
        }
    }
