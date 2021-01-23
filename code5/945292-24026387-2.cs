    public class SomeBehavior
    {
        public static readonly DependencyProperty IsEnabledProperty
            = DependencyProperty.RegisterAttached("IsEnabled",
            typeof(bool), typeof(SomeBehavior), new PropertyMetadata(OnIsEnabledChanged));
        public static void SetIsEnabled(DependencyObject dpo, bool value)
        {
            dpo.SetValue(IsEnabledProperty, value);
        }
        public static bool GetIsEnabled(DependencyObject dpo)
        {
            return (bool)dpo.GetValue(IsEnabledProperty);
        }
        private static void OnIsEnabledChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs args)
        {
            var editor = dpo as TextEditor;
            if (editor == null)
                return;
            var dpDescriptor = System.ComponentModel.DependencyPropertyDescriptor.FromProperty(TextEditor.SelectionLengthProperty,editor.GetType());
            dpDescriptor.AddValueChanged(editor, OnSelectionLengthChanged);
        }
        private static void OnSelectionLengthChanged(object sender, EventArgs e)
        {
            var editor = (TextEditor)sender;
            editor.Select(editor.SelectionStart, editor.SelectionLength);
        }
    }
