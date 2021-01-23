    var input = Console.ReadLine();
    var digits = new List<Char>();
    var numberBars = new List<Int32>();
    var currentNumberBars = 0;
    foreach (var symbol in input)
    {
        if (symbol == '[')
        {
            currentNumberBars++;
        }
        else if (symbol == ']')
        {
            if (currentNumberBars == 0)
            {
                throw new InvalidOperationException();
            }
            currentNumberBars--;
        }
        else if ((symbol >= '0') && (symbol <= '9'))
        {
            digits.Add(symbol);
            numberBars.Add(currentNumberBars);
        }
    }
    if (currentNumberBars != 0)
    {
        throw new InvalidOperationException();
    }
    var maximumNumberBars = numberBars.Max();
    Console.WriteLine();
    for (var i = 0; i < digits.Count; i++)
    {
        Console.WriteLine(digits[i] + new String('|', numberBars[i]).PadLeft(maximumNumberBars));
    }
