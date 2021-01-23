    List<char> input = new List<char>(Console.ReadLine());
    var digits = input.Where(Char.IsDigit);  // 123
    while (digits.Any())
    {
        Console.WriteLine("Enter a string which doesn't contain digits");
        input.Clear();
        input.AddRange(Console.ReadLine());
    }
