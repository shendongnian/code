    List<int> myList = new List<int>() { 5, 7, 12, 8, 7 };
    var allMatchingCombos = new List<IList<int>>();
    for (int lowerIndex = 1; lowerIndex < myList.Count; lowerIndex++)
    {
        IEnumerable<IList<int>> matchingCombos = new Combinations<int>(myList, lowerIndex, GenerateOption.WithoutRepetition)
            .Where(c => c.Sum() == 20);
        allMatchingCombos.AddRange(matchingCombos);
    }
    foreach(var matchingCombo in allMatchingCombos)
        Console.WriteLine(string.Join(",", matchingCombo));
