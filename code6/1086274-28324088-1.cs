    namespace WpfApplication1
    {
        public class InsertXamlBehavior
        {
            public static readonly DependencyProperty KeyProperty =
                DependencyProperty.RegisterAttached("Key", typeof(string), typeof(InsertXamlBehavior), new UIPropertyMetadata(null, new PropertyChangedCallback(OnKeyChanged)));
    
            public static string GetKey(DependencyObject obj)
            {
                return (string)obj.GetValue(KeyProperty);
            }
    
            public static void SetKey(DependencyObject obj, string value)
            {
                obj.SetValue(KeyProperty, value);
            }
    
            private static void OnKeyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
            {
                IAddChild addChild = dependencyObject as IAddChild;
                if (addChild != null)
                {
                    if (args.NewValue != null)
                    {
                        addChild.AddChild(App.Current.FindResource(args.NewValue));
                    }
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }
    }
