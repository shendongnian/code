    class StateBag
    {
        public string Name;
        public string Value;
    }
    class Program
    {
        public static string GetValue(ConcurrentDictionary<string, StateBag> stateBagDict, string name)
        {
            StateBag match;
            return stateBagDict.TryGetValue(name.ToUpperInvariant(), out match) ? 
                match.Value : string.Empty;
        }
        static void Main(string[] args)
        {
            var stateBagDict = new ConcurrentDictionary<string, StateBag>();
            var stateBag1 = new StateBag { Name = "Test1", Value = "Value1" };
            var stateBag2 = new StateBag { Name = "Test2", Value = "Value2" };
            stateBagDict[stateBag1.Name.ToUpperInvariant()] = stateBag1;
            stateBagDict[stateBag2.Name.ToUpperInvariant()] = stateBag2;
            var result = GetValue(stateBagDict, "test1");
            Console.WriteLine(result);
        }
    }
