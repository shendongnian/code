    String name = Console.ReadLine(); // Shows the cursor without a prompt to the user
    System.Console.WriteLine("input name");
    System.Console.WriteLine("hello {0}", name);
    int hello = Console.Read(); // This line reads the new line character (13) from the above line
    System.Console.WriteLine("First number input" + hello); // Displays 13 (new line character if the user doesn't enter any value)
    int hello2 = Console.Read();
    Console.ReadKey(); // Exits the console as soon as a user press a key
    System.Console.WriteLine("Second number input" + hello2); // This is never displays to the user
