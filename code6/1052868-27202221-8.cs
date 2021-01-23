    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        string state = dt.Rows[i][0].ToString();
        string city  = dt.Rows[i][1].ToString();
        if (! dict.Keys.Contains(state ))  dict.Add(state, new List<string>());
        dict[state].Add(city);
    }
