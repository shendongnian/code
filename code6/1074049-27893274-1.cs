    public sealed class TextBoxBehavior
    {
        public static readonly DependencyProperty BufferProperty =
           DependencyProperty.RegisterAttached(
                "Buffer",
                typeof (ITextBuffer),
                typeof (TextBoxBehavior),
                new UIPropertyMetadata(null, PropertyChangedCallback)
            );
    
        private static void PropertyChangedCallback(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs depPropChangedEvArgs)
        {
            var textBox = (TextBox) dependencyObject;
            var textBuffer = (ITextBuffer) depPropChangedEvArgs.NewValue;
    
            textBox.Text = textBuffer.GetCurrentValue();
            textBuffer.BufferAppendedHandler += (sender, appendedText) =>
            {
                textBox.AppendText(appendedText);
            };
    
            // todo unrelease event handlers.
            textBox.TextChanged += (sender, args) =>
            {
                // todo, marshal the changes in `args` to
                // textBuffer.
            };
        }
    
        public static void SetBuffer(UIElement element, Boolean value)
        {
            element.SetValue(BufferProperty, value);
        }
        public static Boolean GetBuffer(UIElement element)
        {
            return (Boolean)element.GetValue(BufferProperty);
        }
    }
