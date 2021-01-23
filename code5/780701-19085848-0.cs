    //Ask for input
    Console.Write("Enter Number of centimetres to be converted: ");
    double input = Console.ReadLine();
    //Convert string to int
    double centimetres = double.Parse(input);
    double inches = centimetres / 2.54;
    //Output result
    Console.WriteLine("Inches = " + inches + "inches.");
