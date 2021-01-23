    public sealed class ChangeBindingBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty ValidateDataErrorsProperty = DependencyProperty.Register("ValidateDataErrors",
            typeof (bool),
            typeof (ChangeBindingBehavior),
            new PropertyMetadata(default(bool), OnValidateDataErrorsChanged));
    
        public bool ValidateDataErrors
        {
            get { return (bool)GetValue(ValidateDataErrorsProperty); }
            set { SetValue(ValidateDataErrorsProperty, value); }
        }
    
        protected override void OnAttached()
        {
            base.OnAttached();
    
            AssociatedObject.Loaded += OnLoaded;
        }
            
        private static void OnValidateDataErrorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue == args.NewValue)
            {
                return;
            }
    
            ((ChangeBindingBehavior)d).OnValidateDataErrorsChanged((bool)args.NewValue);
        }
            
        private void OnValidateDataErrorsChanged(bool newValue)
        {
            if (AssociatedObject == null)
            {
                return;
            }
    
            var expression = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            if (expression != null)
            {
                if (newValue)
                {
                    var newBinding = new Binding("Text")
                    {
                        Path = expression.ParentBinding.Path,
                        Source = AssociatedObject.DataContext,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                        Mode = expression.ParentBinding.Mode,
                        Converter = expression.ParentBinding.Converter
                    };
    
                    AssociatedObject.SetBinding(TextBox.TextProperty, newBinding);
                    AssociatedObject.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
        }
    
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            OnValidateDataErrorsChanged(ValidateDataErrors);
        }
    }
