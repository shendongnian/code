    using Ninject;
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IRepository firstRepo = kernel.Get<IRepository>();
     
            Job myJob1 = new Job(firstRepo);
            // Now myJob1 is instantiated
     
            Console.ReadLine();
        }
    }
