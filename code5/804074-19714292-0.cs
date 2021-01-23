    string inputString;
    double sales;
    double total = 0;
    string initial;
    
    string[] familyNames = {"Anderson","Bowman","Claxton"};
    string[] inital = { "A", "B", "C" };
    double[] totals = new double[3];
    
    Console.Write("Enter family initial: ");
    inputString = Console.ReadLine();
    initial = inputString.ToString();
    
    while (initial != "z" && initial != "Z")
    {
        Console.Write("Enter a sales amount: ");
        inputString = Console.ReadLine();
        sales = Convert.ToDouble(inputString);
        total += sales;
    
        if (initial == "A")
        {
            totals[0] += sales;
        }
        else if (initial == "B")
        {
            totals[1] += sales;
        }
        else if (initial == "C")
        {
            totals[2] += sales;
        }
    
    
        Console.Write("Enter family initial: ");
        inputString = Console.ReadLine();
        initial = inputString.ToString();
    
    }
    Console.WriteLine("Family A earned: {0}", totals[0].ToString("C"));
    Console.WriteLine("Family B earned: {0}", totals[1].ToString("C"));
    Console.WriteLine("Family C earned: {0}", totals[2].ToString("C"));
    Console.WriteLine("Grand Total Sales: {0}",total.ToString("c"));
