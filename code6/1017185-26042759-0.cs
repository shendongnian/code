    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Input;
    namespace StackOverflow
    {
        public class ControlBehavior
        {
            public static DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(ControlBehavior));
            public static DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(ControlBehavior));
            public static DependencyProperty EventProperty = DependencyProperty.RegisterAttached("Event", typeof(string), typeof(ControlBehavior), new PropertyMetadata(PropertyChangedCallback));
            public static void EventHandler(object sender, EventArgs e)
            {
                var s = (sender as DependencyObject);
                if (s != null)
                {
                    var c = (ICommand)s.GetValue(CommandProperty);
                    var p = s.GetValue(CommandParameterProperty);
                    if (c != null && c.CanExecute(s))
                        c.Execute(s);
                }
            }
            public static void PropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs a)
            {
                if (a.Property == EventProperty)
                {
                    EventInfo ev = o.GetType().GetEvent((string)a.NewValue);
                    if (ev != null)
                    {
                        var del = Delegate.CreateDelegate(ev.EventHandlerType, typeof(ControlBehavior).GetMethod("EventHandler"));
                        ev.AddEventHandler(o, del);
                    }
                }
            }
            public string GetEvent(UIElement element)
            {
                return (string)element.GetValue(EventProperty); 
            }
            public static void SetEvent(UIElement element, string value)
            {
                element.SetValue(EventProperty, value);
            }
            public ICommand GetCommand(UIElement element)
            {
                return (ICommand)element.GetValue(CommandProperty);
            }
            public static void SetCommand(UIElement element, ICommand value)
            {
                element.SetValue(CommandProperty, value);
            }
            public object GetCommandParameter(UIElement element)
            {
                return element.GetValue(CommandParameterProperty);
            }
            public static void SetCommandParameter(UIElement element, object value)
            {
                element.SetValue(CommandParameterProperty, value);
            }
        }
    }
