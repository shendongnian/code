    class Program
    {
        static void Main(string[] args)
        {
            const string commaSeperatedPattern = "10,12,14,16";
            const string literallyExpressedPattern = "10 to 20 or 21 or 23";
            int input = 10;
            var commaSeperatedFunc = new CommaSeperatedPatternInterpretter().Interpret(commaSeperatedPattern);
            var literallyExpressedFunc = new LiterallyExpressedPatternInterpretter().Interpret(literallyExpressedPattern);
            Console.WriteLine(string.Format("CommaSeperatedResult: {0} \nLiterallyExpressedResult: {1}",
                                            commaSeperatedFunc(input),
                                            literallyExpressedFunc(input)));
            Console.ReadKey();
        }
    }
    public interface IPatternInterpretter
    {
        Func<int, bool> Interpret(string pattern);
    }
    /// <summary>
    /// Patterns like "10,12,14,16"
    /// </summary>
    public class CommaSeperatedPatternInterpretter : IPatternInterpretter
    {
        public Func<int, bool> Interpret(string pattern)
        {
            Func<int, bool> result = (input) => pattern.Split(',').Select(x => int.Parse(x.Trim())).Contains(input);
            return result;
        }
    }
    /// <summary>
    /// Patterns like "10 to 20 or 21 or 23"
    /// </summary>
    public class LiterallyExpressedPatternInterpretter : IPatternInterpretter
    {
        public Func<int, bool> Interpret(string pattern)
        {
            Func<int, bool> result = (x) => false;
            List<string> items = pattern.Split(' ').Select(x => x.Trim().ToLower()).ToList();
            var ors = new List<int>();
            var intervals = new List<Array>();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                if (item.Equals("or") && i < items.Count-1)
                {
                    ors.Add(int.Parse(items[i + 1]));
                }
                else if (item.Equals("to") && i < items.Count-1 && i > 0)
                {
                    intervals.Add(new int[] {int.Parse(items[i - 1]), int.Parse(items[i + 1])});
                }
            }
            return x => ors.Contains(x) || intervals.Any(i => x > (int) i.GetValue(0) && x < (int) i.GetValue(1));
        }
    }
