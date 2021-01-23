    string[] data = new string[] { "Total Hours Worked (.5);", "Total Hours Worked (.A);", "Total Hours Worked (A);" };
    foreach (string input in data)
    {
        Console.WriteLine("Result for:" + input);
        Match match = Regex.Match(input, @"\([a-z.]+\);$", RegexOptions.IgnoreCase);
        if (match.Success)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
