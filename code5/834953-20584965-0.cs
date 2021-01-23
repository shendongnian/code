    class MyClass1
    {
        public void test()
        {
            StringBuilder one = new StringBuilder("testString1");
            Console.WriteLine("MyClass1: " + one);
            new MyClass2().test(one);
            Console.WriteLine(one); //testString1pilot is printed.
        }
    }
    class MyClass2
    {
        public void test(StringBuilder two)
        {
            Console.WriteLine("Test method");
            Console.WriteLine(two);
            two.Append("pilot");
            Console.WriteLine(two);
        }
    }
