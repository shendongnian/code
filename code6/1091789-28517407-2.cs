    public static class CommandParameterBehavior
    {
        public static readonly DependencyProperty IsCommandRequeriedOnChangeProperty =
            DependencyProperty.RegisterAttached("IsCommandRequeriedOnChange",
                                                typeof(bool),
                                                typeof(CommandParameterBehavior),
                                                new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsCommandRequeriedOnChangeChanged)));
        public static bool GetIsCommandRequeriedOnChange(DependencyObject target)
        {
            return (bool)target.GetValue(IsCommandRequeriedOnChangeProperty);
        }
        public static void SetIsCommandRequeriedOnChange(DependencyObject target, bool value)
        {
            target.SetValue(IsCommandRequeriedOnChangeProperty, value);
        }
        private static void OnIsCommandRequeriedOnChangeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is ICommandSource))
                return;
            if (!(d is FrameworkElement || d is FrameworkContentElement))
                return;
            if ((bool)e.NewValue)
                HookCommandParameterChanged(d);
            else
                UnhookCommandParameterChanged(d);
            UpdateCommandState(d);
        }
        private static PropertyDescriptor GetCommandParameterPropertyDescriptor(object source)
        {
            return TypeDescriptor.GetProperties(source.GetType())["CommandParameter"];
        }
        private static void HookCommandParameterChanged(object source)
        {
            var propertyDescriptor = GetCommandParameterPropertyDescriptor(source);
            propertyDescriptor.AddValueChanged(source, OnCommandParameterChanged);
            // N.B. Using PropertyDescriptor.AddValueChanged will cause "source" to never be garbage collected,
            // so we need to hook the Unloaded event and call RemoveValueChanged there.
            HookUnloaded(source);
        }
        private static void UnhookCommandParameterChanged(object source)
        {
            var propertyDescriptor = GetCommandParameterPropertyDescriptor(source);
            propertyDescriptor.RemoveValueChanged(source, OnCommandParameterChanged);
            UnhookUnloaded(source);
        }
        private static void HookUnloaded(object source)
        {
            var fe = source as FrameworkElement;
            if (fe != null)
            {
                fe.Unloaded += OnUnloaded;
                fe.Loaded -= OnLoaded;
            }
            var fce = source as FrameworkContentElement;
            if (fce != null)
            {
                fce.Unloaded += OnUnloaded;
                fce.Loaded -= OnLoaded;
            }
        }
        private static void UnhookUnloaded(object source)
        {
            var fe = source as FrameworkElement;
            if (fe != null)
            {
                fe.Unloaded -= OnUnloaded;
                fe.Loaded += OnLoaded;
            }
            var fce = source as FrameworkContentElement;
            if (fce != null)
            {
                fce.Unloaded -= OnUnloaded;
                fce.Loaded += OnLoaded;
            }
        }
        static void OnLoaded(object sender, RoutedEventArgs e)
        {
            HookCommandParameterChanged(sender);
        }
        static void OnUnloaded(object sender, RoutedEventArgs e)
        {
            UnhookCommandParameterChanged(sender);
        }
        static void OnCommandParameterChanged(object sender, EventArgs ea)
        {
            UpdateCommandState(sender);
        }
        private static void UpdateCommandState(object target)
        {
            var commandSource = target as ICommandSource;
            if (commandSource == null)
                return;
            var rc = commandSource.Command as RoutedCommand;
            if (rc != null)
                CommandManager.InvalidateRequerySuggested();
            var dc = commandSource.Command as IDelegateCommand;
            if (dc != null)
                dc.RaiseCanExecuteChanged();
        }
    }
