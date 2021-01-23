    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CreateFocus_Click(object sender, RoutedEventArgs e)
        {
            TestTextBox.Focus();
        }
        private void RemoveFocus_Click(object sender, RoutedEventArgs e)
        {
            RemoveFocusBehavior.SetIsRemoveFocus(TestTextBox, true);
        }
    }
    public class RemoveFocusBehavior
    {
        #region IsRemoveFocus Dependency Property
        public static readonly DependencyProperty IsRemoveFocusProperty;
        public static void SetIsRemoveFocus(DependencyObject DepObject, bool value)
        {
            DepObject.SetValue(IsRemoveFocusProperty, value);
        }
        public static bool GetIsRemoveFocus(DependencyObject DepObject)
        {
            return (bool)DepObject.GetValue(IsRemoveFocusProperty);
        }
        static RemoveFocusBehavior()
        {
            IsRemoveFocusProperty = DependencyProperty.RegisterAttached("IsRemoveFocus",
                                                                typeof(bool),
                                                                typeof(RemoveFocusBehavior),
                                                                new UIPropertyMetadata(false, IsRemoveFocusTurn));
        }
        #endregion
        #region IsRemoveFocus Property Metadata
        private static void IsRemoveFocusTurn(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Control control = sender as Control;
            FrameworkElement parent = (FrameworkElement)control.Parent;
            while (parent != null && parent is IInputElement
                                  && !((IInputElement)parent).Focusable)
            {
                parent = (FrameworkElement)parent.Parent;
            }
            DependencyObject scope = FocusManager.GetFocusScope(control);
            FocusManager.SetFocusedElement(scope, parent as IInputElement);
        }
       
        #endregion
    }
