    public static void Main(string[] args)
            {
                var items = new List<string>
                {
                    "Test 1",
                    "test 2"
                };
                WillPrintCorrect(items);
                WillPrintWrong(items);
                BestWay(items);
                Console.ReadLine();
               
            }
    
            public static void WillPrintCorrect(object value)
            {
                 Console.WriteLine(string.Join(Environment.NewLine,(List<string>)value));
            }
    
            public static void WillPrintWrong(object value)
            {
                Console.WriteLine(string.Join(Environment.NewLine, value));
            }
        
            public static void BestWay(List<string> value)
            {
                Console.WriteLine(string.Join(Environment.NewLine, value));
        }
