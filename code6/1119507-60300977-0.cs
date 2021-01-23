    // Put this your forms project
    public class CustomLabel : Label
    {
        public static readonly BindableProperty LineHeightProperty =
            BindableProperty.Create("LineHeight", typeof(double), typeof(CustomLabel));
        public double LineHeight
        {
            get { return (double)GetValue(LineHeightProperty); }
            set { SetValue(LineHeightProperty, value); }
        }
    }
