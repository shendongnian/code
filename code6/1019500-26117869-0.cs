    public class A { public void WhoAreYou() { Console.WriteLine("A"); } }
    public class B : A  { public void WhoAreYou() { Console.WriteLine("B"); } }
    internal class Program
    {
       
    private static void Main(string[] args)
    {
        (new B() as A).WhoAreYou(); // "A"
        (new B()).WhoAreYou(); // "B"
        Console.ReadLine();
    }
