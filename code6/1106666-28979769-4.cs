    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace SelectableTextBoxes
    {
        public class SelectableTextBox : TextBox
        {
            public bool IsSelected { get; private set; }
    
            public SelectableTextBox()
            {
                MouseEnter += SelectableTextBox_MouseEnter;
            }
    
            void SelectableTextBox_MouseEnter(object sender, MouseEventArgs e)
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    IsSelected = true;
                    Background = Brushes.Aqua;
                }
            }
        }
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    }
