    var split = File.ReadAllText(FILENAME)
                    .Replace("<BR>", "").Replace("&nbsp;", " ")
                    .Split(new[] {"<B>", "</B>"}, StringSplitOptions.RemoveEmptyEntries)
                    .Where((x, i) => i%2 == 0)
                    .Select(y => y.Trim()).ToList();
    split.ForEach(Console.WriteLine);
    Console.ReadKey();
