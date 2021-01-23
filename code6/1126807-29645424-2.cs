    int choice = 0;
    while (!Int32.TryParse(Console.ReadLine(), out choice))
    {
         Console.WriteLine("Invalid input, please enter a valid integer");
    }
