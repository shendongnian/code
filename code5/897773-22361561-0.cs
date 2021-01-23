    public class ViewModelLocator
    {
        private IContainer container;
        public ViewModelLocator()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MainViewModel>();
            container = builder.Build();
        }
        public MainViewModel MainViewModel
        {
            get { return container.Resolve<MainViewModel>(); }
        }
    }
