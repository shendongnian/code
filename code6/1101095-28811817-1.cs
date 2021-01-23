    string line = "3 3 9 1 6 5 1 5 3 6";
    int[] input = Array.ConvertAll(line.Split(' '), int.Parse);
    List<int> unique_values = new List<int>();
    SortedDictionary<int, int> lowest_unique_values = new SortedDictionary<int, int>();
    for (int i = 0; i < input.Length; i++)
    {
       if (!unique_values.Contains(input[i]))
       {
          unique_values.Add(input[i]);
          lowest_unique_values.Add(input[i], i);
       }
       else
       {
          lowest_unique_values.Remove(input[i]);
       }
    }
    if (lowest_unique_values.Count > 0)
    {
       // index of smallest unique value
       KeyValuePair<int, int> smallest_value_and_index = lowest_unique_values.First();
       Console.WriteLine(smallest_value_and_index.Key + " " + smallest_value_and_index.Value);
    }
