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
    
            // Handles the mouse down event within the textbox.
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
                        // If a child is not of a correct type, it'll be null.
                        var tbx = child as SelectableTextBox;
                        // This is where we check to see if it's null or this instance.
                        if (tbx != null && tbx != this)
                        {
                            tbx.IsSelected = false;
                        }
                    }
                }
            }
    
            // When textbox receives focus, this event fires... we need to release
            // the mouse.
            void SelectableTextBox_GotMouseCapture(object sender, MouseEventArgs e)
            {
                ReleaseMouseCapture();
            }
    
            // Sets selection state to true if the left mouse button is 
            // down while entering.
            void SelectableTextBox_MouseEnter(object sender, MouseEventArgs e)
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    IsSelected = true;
                }
            }
    
            // Sets the background color based on selection state.
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
    
        // Window code... should be on its own, but I placed the two
        // classes together while prototyping.
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    }
