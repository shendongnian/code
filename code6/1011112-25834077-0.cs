    object[] Mathfunction = new object[] { '+', '-', '*', '/' };
    Console.WriteLine("Enter");
    object input = Console.ReadLine();
    string[] inputString = input.ToString().Split(' ');
    bool isEqual = true;
    for (int i = 0; i < 4; i++)
    {
        if (Mathfunction[i].ToString() != inputString[i])
        {
            isEqual = false;
        }            
    }
    if (isEqual)
    {
        Console.WriteLine("done");
        Console.ReadLine();
    }
