     public class Program
    {
        static void Main(string[] args)
        {
            var pg = new ProxyGenerator();
            //  Intercepted will be an instance of Intercepted class with the           
            //  ModifyStringMethodInterceptor applied to it 
            var intercepted = pg.CreateClassProxy<Intercepted>(new ModifyStringMethodInterceptor());
            intercepted.A = "Set ... ";
            Console.WriteLine(intercepted.A);
            Console.ReadLine();
        }
    }
