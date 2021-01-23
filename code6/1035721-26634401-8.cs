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
            containerBuilder.RegisterType<MyViewModel>();
            container = containerBuilder.Build();
            Program p = new Program();
            MyViewModel vm = p.MyVM;
        }
    }
