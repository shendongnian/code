    Console.Write("\nEnter your number:\t");
    int input = Convert.ToInt32(Console.ReadLine());
    if (input < 10 || input > 100 || arr.Contains(input))
        Console.WriteLine("You did not enter a valid number.");
    else
    {
        arr[a] = input;
        //When they do meet the correct values
        Console.WriteLine("Thanks for entering the number " + arr[a]);
    }
