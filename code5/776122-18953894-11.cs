    string[] x = new[] { "10111", "10122", "10250", "10113" };
    string mostCommonSubstring = x.GetMostCommonSubstrings().FirstOrDefault();
    if (mostCommonSubstring != null)
    {
        for (int i = 0; i < x.Length; i++)
            x[i] = x[i].Replace(mostCommonSubstring, "");
    }
    Console.Write(string.Join(", ", x));
