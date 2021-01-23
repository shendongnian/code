    var list = new List<int>(new[] { 7, 6, 5, 4, 3,9});
    int minValue = list.Min();
    int maxValue = list.Count;
    List<int> test =  Enumerable.Range(minValue, maxValue).ToList();
    var result = Enumerable.Range(minValue, maxValue).Except(list);
    if (result.ToList().Count == 0)
    {
      Console.WriteLine("numbers are in sequence");
    }
    else
    {               
       Console.WriteLine("Numbers are not in sequence");
     }
