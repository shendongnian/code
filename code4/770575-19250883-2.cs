    private string GetMethodName<T>(Expression<Action<T>> method)
    {
        return ((MethodCallExpression)method.Body).Method.Name;
    }
    public void TestMethod()
    {
        Foo foo = new Foo();
        Console.WriteLine(GetMethodName<Foo>(x => foo.Square(1)));
        Console.WriteLine(GetMethodName<Foo>(x => foo.Sum(1,1)));
        Console.ReadLine();
    }
    public class Foo
    {
        public int Bar { get; set; }
    
        public int Sum(int a, int b)
        {
            return a + b;
        }
    
        public int Square(int a)
        {
            return a * a;
        }
    }
    
