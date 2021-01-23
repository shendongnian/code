    public class AfterLoadBehavior
    {
        #region TargetUpdatedAfterLoad Attached Event
        public static readonly RoutedEvent TargetUpdatedAfterLoadEvent = EventManager.RegisterRoutedEvent(
            "TargetUpdatedAfterLoad", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AfterLoadBehavior));
        public static void AddNeedsCleaningHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uiElement = d as UIElement;
            if (uiElement != null)
            {
                uiElement.AddHandler(TargetUpdatedAfterLoadEvent, handler);
            }
        }
        public static void RemoveNeedsCleaningHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uiElement = d as UIElement;
            if (uiElement != null)
            {
                uiElement.RemoveHandler(TargetUpdatedAfterLoadEvent, handler);
            }
        }
        #endregion
        #region RaiseTargetUpdatedAfterLoadEvent Attached Property
        public static bool GetRaiseTargetUpdatedAfterLoadEvent(FrameworkElement obj)
        {
            return (bool)obj.GetValue(RaiseTargetUpdatedAfterLoadEventProperty);
        }
        public static void SetRaiseTargetUpdatedAfterLoadEvent(FrameworkElement obj, bool value)
        {
            obj.SetValue(RaiseTargetUpdatedAfterLoadEventProperty, value);
        }
        public static readonly DependencyProperty RaiseTargetUpdatedAfterLoadEventProperty =
            DependencyProperty.RegisterAttached("RaiseTargetUpdatedAfterLoadEvent", typeof(bool), typeof(AfterLoadBehavior),
            new PropertyMetadata(false, OnRaiseTargetUpdatedAfterLoadEventChanged));
        private static void OnRaiseTargetUpdatedAfterLoadEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)d;
            frameworkElement.AddHandler(Binding.TargetUpdatedEvent, new RoutedEventHandler((sender, args) =>
                {
                    if (GetIsFirstValueChange(frameworkElement))
                    {
                        SetIsFirstValueChange(frameworkElement, false);
                        return;
                    }
                    frameworkElement.RaiseEvent(new RoutedEventArgs(AfterLoadBehavior.TargetUpdatedAfterLoadEvent));
                }));
        }
        #endregion
        #region IsFirstValueChange Attached Property
        public static bool GetIsFirstValueChange(FrameworkElement obj)
        {
            return (bool)obj.GetValue(IsFirstValueChangeProperty);
        }
        public static void SetIsFirstValueChange(FrameworkElement obj, bool value)
        {
            obj.SetValue(IsFirstValueChangeProperty, value);
        }
        
        public static readonly DependencyProperty IsFirstValueChangeProperty =
            DependencyProperty.RegisterAttached("IsFirstValueChange", typeof(bool), typeof(AfterLoadBehavior),
            new PropertyMetadata(true));
        #endregion
    }
