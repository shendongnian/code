    public class MyAnimatedControl : Button
    {
        public static readonly DependencyProperty MyHeightProperty =
            DependencyProperty.Register(
                "MyHeight", typeof(double), typeof(MyAnimatedControl));
        public double MyHeight
        {
            get { return (double)GetValue(MyHeightProperty); }
            set { SetValue(MyHeightProperty, value); }
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            MyHeight = sizeInfo.NewSize.Height;
        }
    }
