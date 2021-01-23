    List<int> tal1 = new List<int>();
    while (input != "0")
    {
      tal1.Add(Convert.ToInt32(input));
      input = Console.ReadLine();
    }
    large = tal1.Max();
