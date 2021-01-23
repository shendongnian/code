    using DevExpress.Xpf.Core.Native;
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace BindingErrorHelper
    {
        public class IsTypeFoundConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                FrameworkElement element = value as FrameworkElement;
                Type type = parameter as Type;
                if (element != null && type != null)
                {
                    element = LayoutHelper.FindElement(element, p => p.GetType() == type);
                    if (element != null)
                        return true;
                }
                return false;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value;
            }
        }
    
        public class LayoutHelper
        {
            public static FrameworkElement FindElement(FrameworkElement treeRoot, System.Predicate<FrameworkElement> predicate)
            {
                VisualTreeEnumerator visualTreeEnumerator = new VisualTreeEnumerator(treeRoot);
                while (visualTreeEnumerator.MoveNext())
                {
                    FrameworkElement frameworkElement = visualTreeEnumerator.Current as FrameworkElement;
                    if (frameworkElement != null && predicate(frameworkElement))
                    {
                        return frameworkElement;
                    }
                }
                return null;
            }
        }
    }
