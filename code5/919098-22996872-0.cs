    public class DoubleClickTrigger : TriggerBase<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnClick), true);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.RemoveHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnClick));
        }
        private void OnClick(object sender, MouseButtonEventArgs args)
        {
            if (args.ClickCount == 1)
                return;
            if (args.ClickCount == 2)
                InvokeActions(null);
        }
    }
