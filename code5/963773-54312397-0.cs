    public static readonly DependencyProperty OneWaySourceRaiseProperty = DependencyProperty.RegisterAttached("OneWaySourceRaise", typeof(object), typeof(FrameworkElementExtended), new FrameworkPropertyMetadata(OneWaySourceRaiseChanged));
    
            public static object GetOneWaySourceRaise(DependencyObject o)
            {
                return o.GetValue(OneWaySourceRaiseProperty);
            }
    
            public static void SetOneWaySourceRaise(DependencyObject o, object value)
            {
                o.SetValue(OneWaySourceRaiseProperty, value);
            }
    
            private static void OneWaySourceRaiseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (e.NewValue == null)
                    return;
    
                var target = (FrameworkElement)d;
                var bindings = target.GetBindings().Where(i => i.ParentBinding?.Mode == BindingMode.OneWayToSource).ToArray();
                foreach (var i in bindings)
                {
                    i.DataItem.SetProperty(i.ParentBinding.Path.Path, d.GetValue(i.TargetProperty));
                }
            }
