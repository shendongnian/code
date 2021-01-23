    public static class FrameworkElementEx
    {
        public static bool GetAttachBehaviors(DependencyObject obj)
        {
            return (bool)obj.GetValue(AttachBehaviorsProperty);
        }
    
        public static void SetAttachBehaviors(DependencyObject obj, bool value)
        {
            obj.SetValue(AttachBehaviorsProperty, value);
        }
    
        public static readonly DependencyProperty AttachBehaviorsProperty =
            DependencyProperty.RegisterAttached("AttachBehaviors", typeof(bool), typeof(FrameworkElementEx), new PropertyMetadata(false, Callback));
    
        private static void Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behaviors = Interaction.GetBehaviors(d);
    
            var eventTriggerBehavior = new EventTriggerBehavior
            {
                EventName = "DoubleTapped"
            };
            eventTriggerBehavior.Actions.Add(new ScrollViewerDoubleTap());
    
            behaviors.Add(eventTriggerBehavior);
        }
    }
