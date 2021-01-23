    var input = "124,456,789,0";
    var parts = input.Split(new [] {","}, StringSplitOptions.RemoveEmptyEntries);
    var numbers
        = parts.Select(x =>
                        {
                            int v;
                            if (!int.TryParse(x, out v))
                                return (int?)null;
                            return (int?)v;
                        }).ToList();
    if (numbers.Any(x => !x.HasValue))
        Console.WriteLine("string cannot be parsed as int[]");
    else
        Console.WriteLine("OK");
