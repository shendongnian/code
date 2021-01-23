    public class MyControlExtension
    {
        public static readonly DependencyProperty SendMahAppsCommandAsEventProperty = DependencyProperty.RegisterAttached("SendMahAppsCommandAsEvent", typeof(bool), ... etc ... );
        public static SetSendMahAppsCommandAsEvent(DependencyObject element, bool value)
        {
            if (value) 
                   TextboxHelper.SetButtonCommand(element, CreateCommand(element));
            else 
                   TextboxHelper.SetButtonCommand(null);
        }
        public static bool GetHeaderSizingGroup(DependencyObject element)
        {
            return (bool) element.GetValue(SendMahAppsCommandAsEventProperty);
        }
        private static ICommand CreateCommand(DependencyObject element) 
        {
              return new MyCommandThatRaisesAttachedEvent(element);
        }
    }
