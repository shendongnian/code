    public static void ConcatTest()
    {
        int NumConcatenations = 10000000;
        const string Postfix = "postfix_";
        /** + Operator concatenation **/
        var sw = Stopwatch.StartNew();
        for (int x = 0; x < NumConcatenations; x++)
        {
            var concatResult = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                concatResult += Postfix;
            }
        }
        var plusOperatorTime = sw.ElapsedMilliseconds;
        Console.WriteLine();
        sw.Reset();
        /** StringBuilder concatenation **/
        sw.Start();
        for (int x = 0; x < NumConcatenations; x++)
        {
            var builder = new StringBuilder(string.Empty);
            for (int i = 0; i < 2; i++)
            {
                builder.Append(Postfix);
            }
        }
        var stringBuilderTime = sw.ElapsedMilliseconds;
        Console.WriteLine(
            "Concatenation with + operator took {0} ms, stringbuilder took {1} ms",
            plusOperatorTime,
            stringBuilderTime);
        Console.ReadLine();
    }
