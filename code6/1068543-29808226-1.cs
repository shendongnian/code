    using Microsoft.Xaml.Interactivity;
    using Windows.UI.Xaml;
    namespace MyBehaviors
    {
        public static class AttachedBehaviorsEx
        {
            public static DataTemplate GetAttachedBehaviors(DependencyObject obj)
            {
                return (DataTemplate)obj.GetValue(AttachedBehaviorsProperty);
            }
            public static void SetAttachedBehaviors(DependencyObject obj, DataTemplate value)
            {
                obj.SetValue(AttachedBehaviorsProperty, value);
            }
            public static readonly DependencyProperty AttachedBehaviorsProperty =
                DependencyProperty.RegisterAttached("AttachedBehaviors", typeof(DataTemplate), typeof(AttachedBehaviorsEx), new PropertyMetadata(null, Callback));
            private static void Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var template = GetAttachedBehaviors(d);
                var value = (BehaviorCollection)template.LoadContent();
                Interaction.SetBehaviors(d, value);
            }
        }
    }
