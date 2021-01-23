    using System.Windows;
    using System.Windows.Media.Animation;
    
    namespace RenderTransformExample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
            {
                var storyboard = (Storyboard)this.Resources["FlipNumberStoryBoard"];
                storyboard.Begin();
            }
        }
    }
