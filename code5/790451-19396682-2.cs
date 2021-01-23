    public partial class MainPage : PhoneApplicationPage
    {
      public static ObservableCollection<string> collection = new ObservableCollection<string>();
      public MainPage()
      {
         InitializeComponent();
         goToPage.Click+=goToPage_Click;
      }
      private void goToPage_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new Uri("/second_page.xaml", UriKind.Relative));
      }
    }
