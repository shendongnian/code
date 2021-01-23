    namespace Teste
    {
        public partial class MainWindow : Window
        {
             public MainWindow()
             {
                InitializeComponent();
             }
             private void Button_Click(object sender, RoutedEventArgs e)
             {
               myWindow newWindow = new myWindow();
               var child = (TextBlock)newWindow.FindName("txtBlock");
               MessageBox.Show(child.Text);
             }
        }
    }
