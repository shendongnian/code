     public sealed partial class MainPage : Page {
         private readonly PostsViewModel _viewmodel;
         public MainPage() {
             this.InitializeComponent();
             this.NavigationCacheMode = NavigationCacheMode.Required;
             _viewmodel = new PostsViewModel();
         }
    }
