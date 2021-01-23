    public class ViewModel
    {
        private ListBox _listBox;
        private void ReceiveListBox(ListBox listBox)
        {
            _listBox = listBox;
        }
        public static readonly DependencyProperty ListBoxHookProperty = DependencyProperty.RegisterAttached(
            "ListBoxHook", typeof (ListBox), typeof (ViewModel), new PropertyMetadata(default(ListBox), ListBoxHookPropertyChangedCallback));
        private static void ListBoxHookPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var listBox = (ListBox) dependencyObject;
            var viewModel = (ViewModel) listBox.DataContext;
            viewModel.ReceiveListBox(listBox);
        }
        public static void SetListBoxHook(DependencyObject element, ListBox value)
        {
            element.SetValue(ListBoxHookProperty, value);
        }
        public static ListBox GetListBoxHook(DependencyObject element)
        {
            return (ListBox) element.GetValue(ListBoxHookProperty);
        }
    }
