    public sealed class MvvmTextBox
    {
        public static readonly DependencyProperty BufferProperty =
            DependencyProperty.RegisterAttached(
                "Buffer",
                typeof (ITextBuffer),
                typeof (MvvmTextBox),
                new UIPropertyMetadata(null, PropertyChangedCallback)
            );
    
        private static void PropertyChangedCallback(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs depPropChangedEvArgs)
        {
            // todo: unrelease old buffer.
            var textBox = (TextBox) dependencyObject;
            var textBuffer = (ITextBuffer) depPropChangedEvArgs.NewValue;
    
            var detectChanges = true;
    
            textBox.Text = textBuffer.GetCurrentValue();
            textBuffer.BufferAppendedHandler += (sender, appendedText) =>
            {
                detectChanges = false;
                textBox.AppendText(appendedText);
                detectChanges = true;
            };
    
            // todo unrelease event handlers.
            textBox.TextChanged += (sender, args) =>
            {
                if (!detectChanges)
                    return;
    
                foreach (var change in args.Changes)
                {
                    if (change.AddedLength > 0)
                    {
                        var addedContent = textBox.Text.Substring(
                            change.Offset, change.AddedLength);
    
                        textBuffer.Append(addedContent, change.Offset);
                    }
                    else
                    {
                        textBuffer.Delete(change.Offset, change.RemovedLength);
                    }
                }
    
                Debug.WriteLine(textBuffer.GetCurrentValue());
            };
        }
    
        public static void SetBuffer(UIElement element, Boolean value)
        {
            element.SetValue(BufferProperty, value);
        }
        public static ITextBuffer GetBuffer(UIElement element)
        {
            return (ITextBuffer)element.GetValue(BufferProperty);
        }
    }
