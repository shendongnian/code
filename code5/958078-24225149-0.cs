    public class c1
    {
       private static int i = 0;
       
       public int alocating_method() //could be protected
       {
            Console.WriteLine("allocating");
            return ++i;
       }
    }
    public class c2 : c1
    {
         static void Main(string[] args)
        {
            c2 p = new c2();
            Console.WriteLine(p.alocating_method());
            Console.WriteLine(p.alocating_method());
        }
    }
