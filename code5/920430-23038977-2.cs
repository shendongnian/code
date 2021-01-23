    public sealed partial class HomePage {
      public HomePage() {
         InitializeComponent();
      }
      public HomeViewModel ViewModel {
         get {
            return (HomeViewModel)DataContext;
         }
      }
      //needed for navigation
      protected override void OnNavigatedTo(NavigationEventArgs e) {
         base.OnNavigatedTo(e);
      }
      //needed for navigation
      protected override void OnNavigatedFrom(NavigationEventArgs e) {
         base.OnNavigatedFrom(e);
      }
    }
