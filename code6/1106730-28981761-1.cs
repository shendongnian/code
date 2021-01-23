    public static class TextBoxBehaviour
    {
        public static readonly DependencyProperty CommandOnEnterPressedProperty = DependencyProperty.RegisterAttached("CommandOnEnterPressed",typeof (ICommand),typeof (TextBoxBehaviour),
                new FrameworkPropertyMetadata(CommandOnEnterPressedPropertyChanged));
        private static void CommandOnEnterPressedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = (TextBox) d;
            sender.KeyDown -= OnKeyDown;
            if (e.NewValue is ICommand)
            {
                sender.KeyDown += OnKeyDown;
            }
        }
        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var tbx = (TextBox) sender;
                var textBindigExpression = tbx.GetBindingExpression(TextBox.TextProperty);
                if (textBindigExpression != null)
                {
                    textBindigExpression.UpdateSource();
                }
                var command = GetCommandOnEnterPressed(tbx);
                if (command.CanExecute(null)) command.Execute(null);
            }
        }
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static void SetCommandOnEnterPressed(TextBox elementName, ICommand value)
        {
            elementName.SetValue(CommandOnEnterPressedProperty, value);
        }
        public static ICommand GetCommandOnEnterPressed(TextBox elementName)
        {
            return (ICommand) elementName.GetValue(CommandOnEnterPressedProperty);
        }
    }
