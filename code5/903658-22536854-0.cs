           static void Main(string[] args)
        {
            int NumConcatenations = 10000;
            const string Postfix = "postfix_";
            var concatResult = string.Empty;
            
            /** + Operator concatenation **/
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < NumConcatenations; i++)
            {
                concatResult += Postfix;
            }
            var plusOperatorTime = sw.ElapsedMilliseconds;
            Console.WriteLine();
            sw.Reset();
            /** StringBuilder concatenation **/
            var builder = new StringBuilder(string.Empty);
            sw.Start();
            for (int i = 0; i < NumConcatenations; i++)
            {
                builder.Append(Postfix);
            }
            var stringBuilderTime = sw.ElapsedMilliseconds;
            Debug.Assert(concatResult.Length == builder.ToString().Length);
            Console.WriteLine(
                "Concatenation with + operator took {0} ms, stringbuilder took {1} ms",
                plusOperatorTime,
                stringBuilderTime);
            Console.ReadLine();
        }
