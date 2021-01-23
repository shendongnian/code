    public class Persistent
    {
        public virtual Persistent Clone()
        {
            return new Persistent();
        }
    }
    public class Animal : Persistent
    {
        public new Animal Clone()
        {
            return new Animal();
        }
    }
    public class Pet : Animal
    {
        
    }
    public class Wild : Animal
    {
        public new Wild Clone()
        {
            return new Wild();
        }
    }
    private static void Test()
    {
        var p = new Persistent().Clone();
        Console.WriteLine("Type of p: {0}", p);
        var a = new Animal().Clone();
        Console.WriteLine("Type of a: {0}", a);
        var t = new Pet().Clone();
        Console.WriteLine("Type of t: {0}", t);
        var w = new Wild().Clone();
        Console.WriteLine("Type of w: {0}", w);
    }
