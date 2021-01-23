    class Program
    {
        static void Main(string[] args)
        {
          double d=0;
          if(d.GetType() == typeof(Char))
          {
            Console.WriteLine("working");
          }
          else 
          { 
            Console.WriteLine("not"); 
          }
          Console.ReadLine();
       }
    }
