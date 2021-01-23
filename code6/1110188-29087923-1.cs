    string input = Console.ReadLine();
    int iSallyAge;
    double dSallyAge;
    if (!Int32.TryParse(input, iSallyAge)) 
    {        
        dSallyAge = Double.Parse(input);
    }
