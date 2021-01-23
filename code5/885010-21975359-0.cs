    public class Foo
    {
        private static int number = 0;
    
        public int GetNumber()
        {
            number = number + 1;
            return number;
        }
    }
    
    public static Main()
    {
        var foo1 = new Foo();
        Console.WriteLine(foo1.GetNumber());
        Console.WriteLine(foo1.GetNumber());
    
        var foo2 = new Foo();
        Console.WriteLine(foo1.GetNumber());
    }
