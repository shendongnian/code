    Console.Write("Please enter your height in centimeters: ");
    var input = Console.ReadLine();
    double result;
    while (!double.TryParse(input, out result))
    {
        Console.Write("{0} is not a valid height. Please try again: ", input);
        input = Console.ReadLine();
    }
            
    Console.WriteLine("Thank you. You entered a valid height of: {0}", result);
