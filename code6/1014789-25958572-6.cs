    public class MyViewModel
    {
        public MyViewModel()
            :this(new Service())
        {}
        public MyViewModel(IService service)
        {
            Service = service;
            Initialize();
        }
        public IService Service { get; set; }
        private async void Initialize()
        {
            // Fire forget
            await Service.DoSomething();
        }
    }
