    class MyClass
    {
        public string Str { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            int c = 3;
            var myObj = new MyClass
            {
                Str = "Whatever"
            };
            Console.WriteLine("{0};\t{1};\t{2};\t{3}", a, b, c, myObj.Str);
            MyFunction(a, ref b, out c, myObj);
            Console.WriteLine("{0};\t{1};\t{2};\t{3}", a, b, c, myObj.Str);
            Console.ReadLine();
        }
        static void MyFunction(int justValue, ref int refInt, out int outInt, MyClass obj)
        {
            obj.Str = "Hello";
            justValue = 101;
            refInt = 102;
            outInt = 103; // similar to refInt, but you MUST set the value of the parameter if it's uses 'out' keyword
        }
    }
