    public class ViewFactory
    {
        private ServiceC _serviceC;
    
        public VewFactory(ServiceC serviceC)
        {
            _serviceC = serviceC;
        }
    
        public View CreateView()
        {
            return new View(new ViewModel(_serviceC));
        }
    }
    
    public class ViewModel1
    {
        private readonly IServiceA serviceA;
        private readonly IServiceB serviceB;
        private ViewFactory _viewFactory;
    
        public ViewModel1(IServiceA serviceA, IServiceB serviceB, ViewFactory viewFactory)
        {
            this.serviceA = serviceA;
            this.serviceB = serviceB;
            _viewFactory = viewFactory;
        }
    
        public void OpenASettingsWindow()
        {
            // How do I resolve this view?
            var window = _viewFactory.CreateView();
        }
    }
