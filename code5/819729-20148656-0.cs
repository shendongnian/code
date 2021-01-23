    var arr1 = new[] { "A", "B", "C", "D", "E" };
    var combinations = new List<string>();
    for(int i = 0; i < arr1.Length; i++)
    {
        for (int j = i; j < arr1.Length; j++)
        {
            if(i != j)
            {
                combinations.Add(string.Format("{0}{1}", arr1[i], arr1[j]));
            }
        }
    }
