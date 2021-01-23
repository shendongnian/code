    class Program
    {
        static void replace(ref ObjectA a, ref ObjectA b) {
            a = b;
        }
        static void Main(string[] args)
        {
            ObjectA a = new ObjectA();
            ObjectA b = new ObjectA();
            Console.Write("a: " + a.GetHashCode() + "\n");
            Console.Write("b: " + b.GetHashCode() + "\n");
            Console.Read();
            replace(ref a, ref b);
            Console.Write("a: " + a.GetHashCode() + "\n");
            Console.Write("b: " + b.GetHashCode() + "\n");
            Console.Read();
        }
    }
    class ObjectA
    {
    }
