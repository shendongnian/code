    int gridSize;
    Console.WriteLine("Enter Grid Size.");
    while(!int.TryParse(Console.ReadLine(), out gridSize))
    {
        Console.WriteLine("That was invalid. Enter a valid Grid Size.");
    }
    // use gridSize here
