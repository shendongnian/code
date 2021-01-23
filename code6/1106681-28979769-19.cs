    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace SelectableTextBoxes
    {
        // Move this class into its own file (it's here for prototyping).
        public class SelectableTextBox : TextBox
        {
            private bool _isSelected;
            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    if (_isSelected != value)
                    {
                        _isSelected = value;
                        // If the value changes, sets new color.
                        SetSelectionColor();
                    }
                }
            }
    
            public SelectableTextBox()
            {
                // For handling an initial click if it happens in the textbox.
                PreviewMouseDown += SelectableTextBox_PreviewMouseDown;
                // For handling selection when mouse enters the textbox
                // and left mouse button is down.
                MouseEnter += SelectableTextBox_MouseEnter;    
                // To handle mouse capture (release it).     
                GotMouseCapture += SelectableTextBox_GotMouseCapture;
            }
    
            void SelectableTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                if (!IsSelected)
                {
                    IsSelected = true;
                }
    
                // This part makes a poor assumption that the parent is
                // always going to be a Panel... expand on this code to
                // cover other types that may contain more than one element.
                var parent = VisualTreeHelper.GetParent(this) as Panel;
    
                if (parent != null)
                {
                    foreach (var child in parent.Children)
                    {
                        var tbx = child as SelectableTextBox;
    
                        if (tbx != null && tbx != this)
                        {
                            tbx.IsSelected = false;
                        }
                    }
                }
            }
    
            void SelectableTextBox_GotMouseCapture(object sender, MouseEventArgs e)
            {
                ReleaseMouseCapture();
            }
    
            void SelectableTextBox_MouseEnter(object sender, MouseEventArgs e)
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    IsSelected = true;
                }
            }
    
            private void SetSelectionColor()
            {
                if (IsSelected)
                {
                    Background = Brushes.LightCyan;
                }
                else
                {
                    Background = Brushes.White;
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
