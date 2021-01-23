    List<IList<int>> allMatchingCombos = Enumerable.Range(1, items.Count)
        .SelectMany(i => new Combinations<int>(items, i, GenerateOption.WithoutRepetition)
                        .Where(c => c.Sum() == 13)
                        .ToList())
        .ToList();
