    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace App19
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
    
            private void ShowButton_Click(object sender, RoutedEventArgs e)
            {
                logincontroler.IsOpen = true;
            }
        }
    }
