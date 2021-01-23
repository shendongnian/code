    string s = "This sample will count: {}, {}, {}.";
    string[] tokens = s.Split(new[] { "{}"}, StringSplitOptions.None);
    StringBuilder sb = new StringBuilder();
    int counter = 1;
    for (int i = 0; i < tokens.Length; i++ )
    {
        sb.Append(tokens[i]);
        if (i < tokens.Length - 1)
            sb.Append(counter++);
    }
    Console.WriteLine(sb.ToString());
