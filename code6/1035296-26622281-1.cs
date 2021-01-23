    List<int> userInts = new List<int>();
    string userValue = Console.ReadLine();
    int userInt;
    if (int.TryParse(out userInt))
    {
        userInts.Add(userInt);
    }
    
