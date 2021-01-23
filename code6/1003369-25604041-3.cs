    private class <Main>b__0
    {
        public int age;
        public void withClosure(string s)
        {
            Console.WriteLine("My name is {0} and I am {1} years old", s, age)
        }
    }
    private static class <Main>b__1
    {
        public static void withoutClosure(string s)
        {
            Console.WriteLine("My name is {0}", s)
        }
    }
    
    public static void Main()
    {
        var b__0 = new <Main>b__0();
        b__0.age = 25;
        Action<string> withClosure = b__0.withClosure;
        Action<string> withoutClosure = <Main>b__1.withoutClosure;
        Console.WriteLine(withClosure.Method.IsStatic);
     	Console.WriteLine(withoutClosure.Method.IsStatic);
    }
