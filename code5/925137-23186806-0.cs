    int age;
    
    if(Int32.TryParse(agestring, out age))
    {
        if (age >= 21)
        {
            Console.WriteLine("congrats, you're you can get drunk!");
        }
        else
        {
            Console.WriteLine("Sorrrrrryyyyyyy =(");
        }   
    }
    else
    {
        Console.WriteLine("Sorry Thats not a valid input");
    }
