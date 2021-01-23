    int num = 0; // initialized num to 0 here
    while (num != 999)
    {
        Console.WriteLine("Enter a number between 0 and 99");
        string input = Console.ReadLine();
        try
        {
            num = Convert.ToInt32(input); // Changed int num to num here
            Console.WriteLine("This is element number " + num + " : " + randNums[num]);
        }
        catch
        {
            Console.WriteLine("Data inputted is not between 0 and 99");
        }
    }
    Console.WriteLine("You chose the secret value, well done!");
