    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfStaff
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                txt2.Text = txt1.Text;
            }
    
            private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                if(txt2!= null)
                    txt2.Text = (sender as TextBox).Text;
            }
        }
    }
