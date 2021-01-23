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
                // Textbox captures the mouse when it receives focus...
                GotMouseCapture += SelectableTextBox_GotMouseCapture;
            }
            void SelectableTextBox_GotMouseCapture(object sender, MouseEventArgs e)
            {
                // Release the mouse when its captured, to be able to continue
                // with the selection.
                ReleaseMouseCapture();
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
