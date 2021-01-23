    internal class Program
    {
        public static IContainer container;
        public MyViewModel MyVM
        {
            get { return Program.container.Resolve<MyViewModel>(); }
        }
        private static void Main(string[] args)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            Console.WriteLine("Before register");
            containerBuilder.RegisterType<MyViewModel>().AutoActivate();
            containerBuilder.RegisterType<MyViewModel>();
            container = containerBuilder.Build();
            Program p = new Program();
            Console.WriteLine("Before property retrieval");
            MyViewModel vm = p.MyVM;
        }
    }
    internal class MyViewModel
    {
        public MyViewModel()
        {
            Console.WriteLine("MyViewModel");
        }
    }
