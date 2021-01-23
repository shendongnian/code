    using Microsoft.Xaml.Interactivity;
    using Windows.UI.Xaml;
    using System;
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
                BehaviorCollection collection = null;
                var template = (DataTemplate)e.NewValue;
                if (template != null)
                {
                    var value = template.LoadContent();
                    if (value is BehaviorCollection)
                        collection = (BehaviorCollection)value;
                    else if (value is IBehavior)
                        collection = new BehaviorCollection { value };
                    else throw new Exception($"AttachedBehaviors should be a BehaviorCollection or an IBehavior.");
                }
                // collection may be null here, if e.NewValue is null
                Interaction.SetBehaviors(d, collection);
            }
        }
    }
