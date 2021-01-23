    public interface INavigationMap<TModel>
        where TModel: PageViewModel
    {
        Type ViewType { get; }
    }
    internal class NavigationMap<TModel, TView> : INavigationMap<TModel>
        where TModel: PageViewModel
        where TView: Page
    {
        public Type ViewType => typeof(TView);
    }
    public class NavigationService : NavigationServiceBase
    {
        private readonly Frame NavigationFrame;
        private readonly ILifetimeScope Resolver;
        public NavigationService(ILifetimeScope scope)
        {
            Resolver = scope;
            NavigationFrame = Window.Current.Content as Frame;
            NavigationFrame.Navigated += NavigationFrame_Navigated;
        }
        private void NavigationFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            if(e.Content is FrameworkElement element)
            {
                element.DataContext = e.Parameter;
                if(e.Parameter is PageViewModel page)
                {
                    CompleteNavigation(page);
                }
            }
        }
        public override void Navigate<TModel>()
        {
            var model = Resolver.Resolve<TModel>();
            var map = Resolver.Resolve<INavigationMap<TModel>>();
            NavigationFrame.Navigate(map.ViewType, model);
        }
    }
