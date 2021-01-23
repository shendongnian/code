    public interface INavigationAware
    {
        Task NavigatedTo(object param);
        Task NavigatedFrom(...)
    }
    public class PersonWindow : ViewModelBase, INavigationAware 
    {
        
    }
