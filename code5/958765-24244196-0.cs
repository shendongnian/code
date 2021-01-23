    var lines = Test.Split(Environment.NewLine);
    string result = String.Empty;
    for (int i = 0; i < lines.Length; i++)
    {
       if (i % 2 == 0)
           result += Environment.NewLine;
       result = lines[i] + Environment.NewLine;
    }
