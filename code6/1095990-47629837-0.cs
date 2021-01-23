    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    namespace NewApp.Cross.Views
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class NewView : ContentPage
        {
            public NewView()
            {
                InitializeComponent();
                Title = "PageTitle"
    
                NavigationPage.SetHasBackButton(this, false);
    
                ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
                ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
            }
        }
    }
