    public class CustomControl : FrameworkElement
    {
        public static readonly DependencyProperty BackgroundProperty =
            Control.BackgroundProperty.AddOwner(typeof(CustomControl));
        public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext); // just good practice
            drawingContext.DrawRectangle(Background, null, new Rect(RenderSize));
            // your rendering code goes here...
        }
    }
