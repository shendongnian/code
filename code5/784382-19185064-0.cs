    while (matches.Success)
    {
        string test = matches.ToString();
        if (test.Contains(SearchValue))
        {
            count++;
            Console.WriteLine("Result #{0}: '{1}' found in the source code at position {2}.", count, matches.Value, matches.Index);
        }
        matches = matches.NextMatch(); //moved this outside the if
    }
