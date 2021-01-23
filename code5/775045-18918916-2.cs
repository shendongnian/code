    List<int> items = new List<int> { 200, 100, 50, 20, 10, 5, 2, 1 };
    var allMatchingCombos = new List<IList<int>>();
    for (int i = 1; i < items.Count; i++)
    {
        IEnumerable<IList<int>> matchingCombos = new Combinations<int>(items, i, GenerateOption.WithoutRepetition)
            .Where(c => c.Sum() == 13);
         allMatchingCombos.AddRange(matchingCombos);
    }
    foreach(var combo in allMatchingCombos)
       Console.WriteLine(string.Join(",", combo));
