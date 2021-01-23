    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }
        public static class Msgbox {
            static public async void Show(string m) {
                var dialog = new MessageDialog( m);            
                await dialog.ShowAsync();
            }
        }
    
        private void Button_Click(object sender, RoutedEventArgs e) { 
            Msgbox.Show("This is a test to see if the message box work");
            //Content.ToString();
        }
    }
