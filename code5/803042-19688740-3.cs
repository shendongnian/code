    struct MutableStruct
    {
        public int EvilInt { get; set; }    
    }
    class Program
    {        
        static void Main(string[] args)
        {
            var testStruct = new MutableStruct();
            testStruct.EvilInt = 1;
            int test = 1;
            Increment(test, testStruct);
            Console.WriteLine("After increment: " + test + " and..." + testStruct.EvilInt);//both 1
        }
        static void Increment(int test, MutableStruct test2)
        {
            test2.EvilInt += 1;
            test += 1;
            Console.WriteLine(test + " and..." + test2.EvilInt);//both 2
        }
    }
