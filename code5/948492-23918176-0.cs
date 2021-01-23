    public class myclass
    {
        int value = 0;
        const int tries = 10000;
        public int Go()
        {
            Thread t1 = new Thread(method1);
            t1.Start();
            Thread t2 = new Thread(method2);
            t2.Start();
            t1.Join();
            t2.Join();
            return value;
        }
        public void method1()
        {
            for (int x = 0; x < tries; x++)
            {
                value++;
            }
    
        }
        public void method2()
        {
            for (int x = 0; x < tries; x++)
            {
                value--;   
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var c = new myclass();
            int counter = 0; 
            for(int x  = 0 ; x < 100 ; x++)
            {
                if(c.Go() != 0)
                {
                    Console.WriteLine("Iteration {0} doesn't = 0", x);
                }
            }
        }
