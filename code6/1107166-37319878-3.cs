    class FunctionMapUsage
    {
        private FunctionDictionary functions = new FunctionDictionary();
        public string FunctionA()
        {
            return "A";
        }
        public string FunctionB(int value)
        {
            return value.ToString();
        }
        public int FunctionC(string str1, string str2)
        {
            return str1.Length + str2.Length;
        }
        public void CreateFunctionMap()
        {
            functions.Add<string>("A", FunctionA);                      // Add Function A to map
            functions.Add<int, string>("B", FunctionB);                 // Add Function B to map
            functions.Add<string, string, int>("C", FunctionC);         // Add Function C to map
        }
        public void CallFunctions()
        {
            var functionA = functions.Function<string>("A");                // Get Function A
            var functionB = functions.Function<int, string>("B");           // Get Function B
            var functionC = functions.Function<string, string, int>("C");   // Get Function C
            string resultA = functionA();
            string resultB = FunctionB(123);
            int resultC = functionC("parameter 1", "parameter 2");
        }
    }
