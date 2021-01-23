    public class DialogWindow : Window {
        // All your code here . . .
        public MainWindow Parent { get; set; }
        private void Button_Click_SaveImage( object sender, RoutedEventArgs e ) {
            // Your code up to the MainWindow a line goes here
            Parent.Refreshicon();
        }
    }
