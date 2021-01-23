    public static readonly DependencyProperty ViewAspectProperty = DependencyProperty.Register(nameof(ViewAspect), typeof(Point), typeof(CustomEffect), new UIPropertyMetadata(new Point(1D, 1D), PixelShaderConstantCallback(0)));
        public Point ViewAspect
        {
            get => (Point)GetValue(ViewAspectProperty);
            set => SetValue(ViewAspectProperty, value);
        }
