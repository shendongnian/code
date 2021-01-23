    public partial class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
        }
        public MainViewModel MainVM
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }
    }
    <phone:PhoneApplicationPage
        ...
        x:Class="Namespace.MainPage"
        DataContext="{Binding Source={StaticResource Locator}, Path=MainVM}"
    </phone:PhoneApplicationPage>
