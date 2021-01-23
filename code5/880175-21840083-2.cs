    int[] myNumbers = new int[2];
    
    for(int i = 0; i < 2; i++)
    {
        if i == 0  //  bad
            string prompt = "Enter the first number";
        else
            string prompt = "Enter the second number";
     
        Console.WriteLine(prompt);
        myNumbers[i] = int.Parse(Console.ReadLine());
    }
