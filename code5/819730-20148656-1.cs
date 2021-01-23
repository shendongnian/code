    var arr1 = new[] { "A", "B", "C", "D", "E" };
    var combinations = new List<string>();
    for(int i = 0; i < arr1.Length; i++)
    {
        for (int j = i + 1; j < arr1.Length; j++)
        {
            combinations.Add(string.Format("{0}{1}", arr1[i], arr1[j]));
        }
    }
