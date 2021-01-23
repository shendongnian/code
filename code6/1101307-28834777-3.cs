    public interface INavigationService 
    {
        // T is whatever your base ViewModel class is called
        void NavigateTo<T>() where T ViewModel;
        void NavigateToNewWindow<T>();
        void NavigateToNewWindow<T>(object parameter);
        void NavigateTo<T>(object parameter);
    }
