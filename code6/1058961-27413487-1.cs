    public static class ViewModelLocator
    {
        private static MyViewModel _myViewModel = new MyViewModel();
        public static MyViewModel MainViewModel
        {
            get
            {
                return _myViewModel;
            } 
        } 
    }
    ...
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            BindingContext = ViewModelLocator.MainViewModel;
        }
    }
    ...
    public partial class SomeOtherView : ContentPage
    {
        public SomeOtherView()
        {
            BindingContext = ViewModelLocator.MainViewModel;
        }
    }
