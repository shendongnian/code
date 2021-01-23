    public class GrowOnlyWidthBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SizeChanged += OnSizeChanged;
        }
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            AssociatedObject.MinWidth = Math.Max(AssociatedObject.MinWidth, AssociatedObject.ActualWidth);
        }
    }
