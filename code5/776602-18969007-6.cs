     public class AvalonTextBehavior : Behavior<TextEditor>
        {
            public static readonly DependencyProperty GiveMeTheTextProperty =
                    DependencyProperty.Register("GiveMeTheText", typeof (string), typeof (AvalonTextBehavior), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PropertyChangedCallBack));
    
    private static void PropertyChangedCallback(DependencyObject dependencyObject,
                                                        DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
            {
                var editor = dependencyObject as TextEditor;
                if (editor != null)
                {
                    if (editor.TextDocument != null)
                    {
                        editor.TextDocument.Text = dependencyPropertyChangedEventArgs.NewValue.ToString();
                    }
                }
            }
            public string GiveMeTheText
            {
                get { return (string) GetValue(GiveMeTheTextProperty); }
                set { SetValue(GiveMeTheTextProperty, value); }
            }
        protected override void OnAttached()
        {
            base.OnAttached();
            if (AssociatedObject != null)
            {
                AssociatedObject.TextChanged += AssociatedObjectOnTextChanged;
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.TextChanged -= AssociatedObjectOnTextChanged;
            }
        }
        private void AssociatedObjectOnTextChanged(object sender,
                                                   EventArgs eventArgs)
        {
            var textEditor = sender as TextEditor;
            if (textEditor != null)
            {
                if (textEditor.Document != null)
                {
                    GiveMeTheText = textEditor.Document.Text;
                }
            }
        }
    }
