    class Program
    {
        public static string GetData(string item) { return item; }
        public static string GetData(int item) { return item.ToString(); }
        static void Main(string[] args)
        {
            string someLocalVar = "what is it?";
            // This ...
            Func<string> test = () =>
            {
                return GetData(someLocalVar);
            };
            // Same as this
            Func<string> test2 = () => GetData(4);
            List<Func<string>> testList = new List<Func<string>>();
            // same as this, just in line, all OK
            testList.Add(() => GetData(someLocalVar));
            testList.Add(() => GetData(2));
            testList.Add(test);
            testList.Add(test2);
            // changing this value will affect the delegates prior to execution
            someLocalVar = "something else";
            foreach(var func in testList)
            {
                Console.WriteLine(func());
            }
            Console.ReadKey();
        }
    }
