    public class GrowOnlyWidthBehavior: Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SizeChanged += OnSizeChanged;
        }
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!e.WidthChanged)
                return;
            if (e.NewSize.Width < e.PreviousSize.Width)
                e.Handled = true;
        }
    }
