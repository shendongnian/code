         public static class MouseCommandBehavior
         {
              public static readonly DependencyProperty MouseDownCommandProperty =
                            DependencyProperty.RegisterAttached("MouseDownCommand",
                            typeof(ICommand),
                            typeof(MouseCommandBehavior),
                            new FrameworkPropertyMetadata(null, (obj, e) => OnMouseCommandChanged(obj, (ICommand)e.NewValue, false)));
 
         public static ICommand GetMouseDownCommand(DependencyObject d)
         {
                 return (ICommand)d.GetValue(MouseDownCommandProperty);
         }
 
          public static void SetMouseDownCommand(DependencyObject d, ICommand value)
         {
             d.SetValue(MouseDownCommandProperty, value);
         }
 
         private static void OnMouseCommandChanged(DependencyObject d, ICommand command)
         {
               if (command == null) return;
 
                var element = (FrameworkElement)d;
 
                element.PreviewMouseDown += (obj, e) => command.Execute(null);
          }
         }
        }
