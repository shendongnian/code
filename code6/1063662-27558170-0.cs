    int hello;
    while(!int.TryParse(Console.ReadLine(), out hello)
    {
       // This will happen if the user types something that's not a number
       Console.WriteLine("Please enter a valid number:"); 
    }
    Console.WriteLine("First number input" + hello);
