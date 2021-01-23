        public class SuppressButtonClickBehavior : Behavior<Button>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                AssociatedObject.AddHandler(UIElement.PreviewMouseLeftButtonDownEvent, 
                                            new RoutedEventHandler(OnPreviewMouseLeftButtonDown),
                                            true);
            }
            protected override void OnDetaching()
            {
                base.OnDetaching();
                AssociatedObject.RemoveHandler(UIElement.PreviewMouseLeftButtonDownEvent,
                                               new RoutedEventHandler(OnPreviewMouseLeftButtonDown));
            }
            private void OnPreviewMouseLeftButtonDown(Object sender, RoutedEventArgs e)
            {
                e.Handled = true;
                if (AssociatedObject.Command != null)
                {
                    AssociatedObject.Command.Execute(AssociatedObject.CommandParameter);
                }
            }
        }
