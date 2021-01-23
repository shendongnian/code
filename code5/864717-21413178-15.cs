    class Program
    {
        public static string GetData(string item) { return item; }
        public static string GetData(int item) { return item.ToString(); }
        static void Main(string[] args)
        {
            string someLocalVar = "what is it?";
            int someLocalValueType = 3;
            Func<string> test = () =>
            {
                return GetData(someLocalVar);
            };
            Func<string> test2 = () => GetData(someLocalValueType);
            someLocalValueType = 5;
            List<Func<string>> testList = new List<Func<string>>();
            testList.Add(() => GetData(someLocalVar));
            testList.Add(() => GetData(2));
            testList.Add(test);
            testList.Add(test2);
            someLocalVar = "something else";
            foreach(var func in testList)
            {
                Console.WriteLine(func());
            }
            Console.ReadKey();
        }
    }
