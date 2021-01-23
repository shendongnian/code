    public class TextBoxExtension
    {
        public static readonly DependencyProperty AttachedTextProperty;
        static TextBoxExtension()
        {
            AttachedTextProperty = DependencyProperty.RegisterAttached("AttachedText", typeof (string), typeof (TextBoxExtension), new PropertyMetadata(default(string), TextAttachedChanged));
        }
        public static string GetAttachedText(TextBox sender)
        {
            return (string) sender.GetValue(AttachedTextProperty);
        }
        public static void SetAttachedText(TextBox sender, string value)
        {
            sender.SetValue(AttachedTextProperty, value);
        }
        private static void TextAttachedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextBox) sender).Text = e.NewValue as string;
        }
    }
