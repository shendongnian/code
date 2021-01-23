      public class AutoFocusBehavior : DependencyObject
    {
        public static bool IsAutoFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsAutoFocusProperty);
        }
        public static void SetIsAutoFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(IsAutoFocusProperty, value);
        }
        public static readonly DependencyProperty IsAutoFocusProperty =
            DependencyProperty.RegisterAttached("IsAutoFocus", typeof(bool), typeof(AutoFocusBehavior),
                new PropertyMetadata(false, new PropertyChangedCallback((d, de) =>
                {
                    if ((bool)de.NewValue)
                    {
                        FrameworkElement frameworkElement = (FrameworkElement)d;
                        frameworkElement.Unloaded += frameworkElement_Unloaded;
                        frameworkElement.IsVisibleChanged += new DependencyPropertyChangedEventHandler(frameworkElement_IsVisibleChanged);
                        frameworkElement.IsEnabledChanged += frameworkElement_IsEnabledChanged;
                    }
                    else
                    {
                        FrameworkElement frameworkElement = (FrameworkElement)d;
                        frameworkElement.Unloaded -= frameworkElement_Unloaded;
                        frameworkElement.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(frameworkElement_IsVisibleChanged);
                        frameworkElement.IsEnabledChanged -= frameworkElement_IsEnabledChanged;
                    }
                })));
        static void frameworkElement_Unloaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement frameworkElement = (FrameworkElement)sender;
            frameworkElement.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(frameworkElement_IsVisibleChanged);
            frameworkElement.IsEnabledChanged -= frameworkElement_IsEnabledChanged;
        }
        static void frameworkElement_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.NewValue))
            {
                if (sender is System.Windows.Controls.TextBox)
                {
                    System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
                    if (textBox != null)
                    {
                        textBox.SelectAll();
                    }
                }
                ((FrameworkElement)sender).Focus();
            }
        }
        static void frameworkElement_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((bool)e.NewValue))
            {
                if (sender is System.Windows.Controls.TextBox)
                {
                    System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
                    if (textBox != null)
                    {
                        textBox.SelectAll();
                        textBox.Focus();
                    }
                }
                ((FrameworkElement)sender).Focus();
            }
        }
    }
