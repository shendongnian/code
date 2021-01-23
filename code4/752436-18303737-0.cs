    //Prompt for input
    System.Console.WriteLine("Please enter the name");
    System.Console.Write("Name> ");
    string name = System.Console.ReadLine();
    string text;
    if (new[] {"Jack", "Ken", "Wizard"}.Contains(name))
    {
        // Fetch the file from input
        text = System.IO.File.ReadAllText(@"D:\Users\Jack\Documents\Test\" + name + ".txt");
    }
    // Display the attributes to the console.
    System.Console.WriteLine("");
    System.Console.WriteLine("{0}", text);
