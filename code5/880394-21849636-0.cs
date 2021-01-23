    public class DependencyProperties
    {
        public static readonly DependencyProperty SelectionBeginProperty;
        public static void SetSelectionBegin(DependencyObject DepObject, int value)
        {
            DepObject.SetValue(SelectionBeginProperty, value);
        }
        public static int GetSelectionBegin(DependencyObject DepObject)
        {
            return (int)DepObject.GetValue(SelectionBeginProperty);
        }
        
        static DependencyProperties()
        {
            SelectionBeginProperty = DependencyProperty.RegisterAttached("SelectionBegin", // RegisterAttached
                                                                 typeof(int),
                                                                 typeof(DependencyProperties), // Name of your class
                                                                 new UIPropertyMetadata(0, SelectionStartDependencyPropertyChanged));
        }
        private static void SelectionStartDependencyPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) 
        {
            // Some logic
            var textBox = sender as TextBox;
            if (textBox == null) 
            {
                return;
            }
            if (e.NewValue is int && ((int)e.NewValue) > 0)
            {
                textBox.Background = Brushes.Red;
            }
        }
    }
