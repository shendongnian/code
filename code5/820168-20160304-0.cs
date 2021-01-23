    class Program
    {
        private static List<Action> actionList = new List<Action>();
        public static void Main(string[] args)
        {
            actionList.Add(() => Console.WriteLine("Test 1!"));
            actionList.Add(() => Console.WriteLine("Test {0}!", 2));
            foreach (var action in actionList)
            {
                action();
            }
        }
    }
