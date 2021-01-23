    namespace Project1
    {
    public partial class Program1
    {       
        private void F1()
        {
            Console.WriteLine("F1");
        }
    
        private void F2()
        {
            Console.WriteLine("F2");
        }
    
        static void Main(string[] args)
        {
            var program1 = new Program1();
            program1.F1();
        }
    }
    }
