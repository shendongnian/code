    namespace RealmApp1.Views
    {
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
                BindingContext = new MainPageViewModel();
            }      
        }
    }
