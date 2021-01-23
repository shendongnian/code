    public abstract class NavigableViewModel : ViewModelBase
    {
        public abstract void OnNavigatedTo(object parameter = null);
        public abstract void OnNavigatingTo(object parameter = null);
    }
