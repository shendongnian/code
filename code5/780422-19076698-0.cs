    string chars = "091";
    string ss = "763091d44a0914";
    List<int> indexes = new List<int>();
    foreach ( Match match in Regex.Matches(ss, chars) )
    {
         indexes.Add(match.Index);
    }
    for (int i = 0; i < indexes.Count; i++)
    {
         Console.WriteLine("{0}. match in index {1}", i+1, indexes[i]);
    }
