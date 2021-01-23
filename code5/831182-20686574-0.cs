    public class ClassWithFinalizer 
    {
        ~ClassWithFinalizer()
        {
            Console.WriteLine("hello from finalizer");
            //do nothing
        }
    }
    static void Main(string[] args)
    {
        ClassWithFinalizer a = new ClassWithFinalizer();
        Console.WriteLine("Class a is on #{0} generation", GC.GetGeneration(a));
        GC.Collect();
        Console.WriteLine("Class a is on #{0} generation", GC.GetGeneration(a));
        GC.Collect();
        Console.WriteLine("Class a is on #{0} generation", GC.GetGeneration(a));
        
        a = null;
        Console.WriteLine("Collecting 0 Gen");
        GC.Collect(0);
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Collecting 0 and 1 Gen");
        GC.Collect(1);
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Collecting 0, 1 and 2 Gen");
        GC.Collect(2);
        GC.WaitForPendingFinalizers();
        
        Console.Read();
    }
