    class Test
    {
        static void Func(ref StringBuilder myString)
        {
            myString.Append("test");
            myString = null;
        }
        static void Main(string[] args)
        {
            StringBuilder s1 = new StringBuilder();
            Func(ref s1);
            Console.WriteLine(s1);
        }
    }
