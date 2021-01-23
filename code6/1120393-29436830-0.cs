    public static class ListBoxFix
    {
        public static bool GetSelectedItemsBinding(ListBox element)
        {
            return (bool)element.GetValue(SelectedItemsBindingProperty);
        }
        public static void SetSelectedItemsBinding(ListBox element, bool value)
        {
            element.SetValue(SelectedItemsBindingProperty, value);
        }
        public static readonly DependencyProperty SelectedItemsBindingProperty =
            DependencyProperty.RegisterAttached("SelectedItemsBinding",
            typeof(bool), typeof(ListBoxFix), new PropertyMetadata(false));
    }
