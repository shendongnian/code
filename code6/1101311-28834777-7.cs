    public class NavigationService : INavigationService
    {
        private IUnityContainer container;
        public NavigationService(IUnityContainer container) 
        {
            this.container = container;
        }
        public void NavigateToWindow<T>(object parameter) where T : IView
        {
            // configure your IoC container to resolve a View for a given ViewModel
            // i.e. container.Register<IPlotView, PlotWindow>(); in your
            // composition root
            IView view = container.Resolve<T>();
            Window window = view as Window;
            if(window!=null)
                window.Show();
            INavigationAware nav = view as INavigationAware;
            if(nav!= null)
                nav.NavigatedTo(parameter);
        }
    }
    // IPlotView is an empty interface, only used to be able to resolve
    // the PlotWindow w/o needing to reference to it's concrete implementation as
    // calling navigationService.NavigateToWindow<PlotWindow>(userId); would violate 
    // MVVM pattern, where navigationService.NavigateToWindow<IPlotWindow>(userId); doesn't. There are also other ways involving strings or naming
    // convention, but this is out of scope for this answer. IView would 
    // just implement "object DataContext { get; set; }" property, which is already
    // implemented Control objects
    public class PlotWindow : Window, IView, IPlotView
    {
    }
