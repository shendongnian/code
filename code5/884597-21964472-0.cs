    //Create an integer variable to hold a redom number
    int answer = 0;
    int guess = 0;
    //Creates an object of the Random class
    Random number = new Random();
    answer = number.Next(1, 11);
    //Creates for loop
    for (int i = 1; i <= 6; i++)
    {
        if (i > 5)
        {
            Console.WriteLine("Your Lose.  The answer is {0}", answer);
            break;
        }
        Console.Write("Enter Guess {0}:", i);
        guess = Convert.ToInt32(Console.ReadLine());
        if (guess == answer)
        {
            Console.WriteLine("You Won!!    {0} is the correct number", answer);
            break;
        }
        else if (guess < answer)
        {
            Console.WriteLine("Guess is lower");
        }
        else if (guess > answer)
        {
            Console.WriteLine("Guess is higher");
        }
    }//end of for loop
    //Pause Display
    Console.ReadKey();
