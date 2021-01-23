    public class CenterBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            UpdatePosition();
            AssociatedObject.SizeChanged += OnSizeChanged;
        }
        private void UpdatePosition()
        {
            Canvas.SetLeft(AssociatedObject, -AssociatedObject.Width/2);
            Canvas.SetTop(AssociatedObject, -AssociatedObject.Height/2);
        }
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePosition();
        }
    }
