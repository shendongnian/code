    using System.Collections;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    public static class ComboBoxItemsSourceDecorator
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.RegisterAttached(
            "ItemsSource",
            typeof(IEnumerable),
            typeof(ComboBoxItemsSourceDecorator),
            new PropertyMetadata(null, ItemsSourcePropertyChanged));
        public static void SetItemsSource(UIElement element, bool value)
        {
            element.SetValue(ItemsSourceProperty, value);
        }
        public static IEnumerable GetItemsSource(UIElement element)
        {
            return (IEnumerable)element.GetValue(ItemsSourceProperty);
        }
        private static void ItemsSourcePropertyChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            var target = element as ComboBox;
            if (element == null)
            {
                return;
            }
            // Save original binding 
            var originalBinding = BindingOperations.GetBinding(target, ComboBox.TextProperty);
            BindingOperations.ClearBinding(target, ComboBox.TextProperty);
            try
            {
                target.ItemsSource = e.NewValue as IEnumerable;
            }
            finally
            {
                if (originalBinding != null)
                {
                    BindingOperations.SetBinding(target, ComboBox.TextProperty, originalBinding);
                }
            }
        }
    }
