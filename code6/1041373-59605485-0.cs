    // I would not get into how the ViewModel or property change notification is implemented
    public abstract class PageViewModel : ViewModel
    {
        protected internal INavigationService Navigation { get; internal set; }
        internal void NavigationCompleted()
        {
            OnNavigationCompleted();
        }
        protected virtual void OnNavigationCompleted()
        {
        }
    }
    public interface INavigationService
    {
        void Navigate<TModel>() where TModel : PageViewModel;
    }
    public abstract class NavigationServiceBase : INavigationService
    {
        public abstract void Navigate<TModel>() where TModel : PageViewModel;
        protected void CompleteNavigation(PageViewModel model)
        {
            model.Navigation = this;
            model.NavigationCompleted();
        }
    }
