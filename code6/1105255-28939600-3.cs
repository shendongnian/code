    public class CustomSlider : Slider
    {
        public static readonly DependencyProperty CustomObjectProperty =
            DependencyProperty.Register(
                "CustomObject",
                typeof(CustomObject),
                typeof(CustomSlider),
                new FrameworkPropertyMetadata(null));
        public CustomObject CustomObject
        {
            get { return (CustomObject)GetValue(CustomObjectProperty); }
            set { SetValue(CustomObjectProperty, value); }
        }
    }
