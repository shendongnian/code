    List<string> numbers = new List<string>();
    for (int i = 49; i >= 1; i--) {
        numbers.Add(i.ToString());
    
    }
    string numberWithCommas = String.Join(",", numbers);
    Console.WriteLine(numberWithCommas);
