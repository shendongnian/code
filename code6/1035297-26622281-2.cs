    List<int> userInts = new List<int>();
    for (int i = 0; i < 5; i++)
    {
        string userValue = Console.ReadLine();
        int userInt;
        if (int.TryParse(out userInt))
        {
            userInts.Add(userInt);
        }
    }
    
