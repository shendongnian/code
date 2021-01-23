    public interface ITest { }
    public class Test : ITest { }
    private static void Main(string[] args)
    {
        test(new Test() ); // outputs "anything" because Test is matched to any type T before ITest
        Console.ReadLine();
    }
    public static void test<T>(T anything)
    {
        Console.WriteLine("anything");
    }
    public static void test(ITest it)
    {
        Console.WriteLine("it");
    }
