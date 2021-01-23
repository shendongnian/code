    class Program
    {
        private static List<Action> actionList = new List<Action>();
        public static void Main(string[] args)
        {
            var testString = "Test 1";
            actionList.Add(() => Console.WriteLine(testString));
            testString = "Test 2";
            actionList.Add(() => Console.WriteLine(testString));
            foreach (var action in actionList)
            {
                action();
            }
        }
    }
