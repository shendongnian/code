    public class blahblah
    {
        int x, y = 2;   // this sets y as 2, but x is not set 
        public void count()
        {
            Console.WriteLine("Hi: " + y);
        }
        public void counting()
        {
            int z =  x * y;
            Console.WriteLine("Z = {0}", z);
           
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            blahblah b = new blahblah(); //instantiate the object
            b.count();  //call a method on the object
            b.counting();
            Console.ReadKey();
        }
    }    
    
    // output:
    // Hi: 2
    // z = 0
