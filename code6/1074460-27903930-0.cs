    List<int> Numbers = new List<int>();
    if (Numbers.Count > 10)
    {
        Numbers.RemoveRange(0, 0);
    }
    Numbers.Add(11);
    var NewAverage = Numbers.Average();
