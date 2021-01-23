    public class AngularGradientEffect : ShaderEffect
    {
        const int STOP_COUNT = 20;
        const int STOP_ANGLE_OFFSET = 10;
        const int STOP_COLOR_OFFSET = 50;
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty(
            "Input",
            typeof(AngularGradientEffect),
            0);
        public static readonly DependencyProperty CenterPointProperty = DependencyProperty.Register(
            "CenterPoint",
            typeof(Point),
            typeof(AngularGradientEffect),
            new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty GradientStopsProperty =
            DependencyProperty.Register("GradientStops",
            typeof(GradientStopCollection),
            typeof(AngularGradientEffect),
            new PropertyMetadata(new GradientStopCollection()));
        static readonly DependencyProperty[] StopAngles = new DependencyProperty[STOP_COUNT];
        static readonly DependencyProperty[] StopColors = new DependencyProperty[STOP_COUNT];
        static AngularGradientEffect()
        {
            for (int i = 0; i < STOP_COUNT; i++)
            {
                StopAngles[i] = DependencyProperty.Register("GradientStopAngle" + i, typeof(float), typeof(AngularGradientEffect), new UIPropertyMetadata(-1.0f, PixelShaderConstantCallback(STOP_ANGLE_OFFSET + i)));
                StopColors[i] = DependencyProperty.Register("GradientStopColor" + i, typeof(Color), typeof(AngularGradientEffect), new UIPropertyMetadata(Colors.RosyBrown, PixelShaderConstantCallback(STOP_COLOR_OFFSET + i)));
            }
        }
        public AngularGradientEffect()
        {
            PixelShader = new PixelShader()
            {
                UriSource = new Uri("/ShaderTest;component/shader.ps", UriKind.Relative)
            };
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(CenterPointProperty);
            GradientStops = new GradientStopCollection();
            GradientStops.Changed += GradientStops_Changed;
        }
        void GradientStops_Changed(object sender, EventArgs e)
        {
            SetGradientStopDependencyProperties(sender as GradientStopCollection);
        }
        public void SetGradientStopDependencyProperties(IEnumerable<GradientStop> stops)
        {
            var orderedStops = stops.OrderBy(s => s.Offset).ToArray();
            for (int i = 0; i < STOP_COUNT; i++)
            {
                var current = orderedStops.ElementAtOrDefault(i);
                DependencyProperty angleProperty = StopAngles[i];
                SetValue(angleProperty, current == null ? -1.0f : (float)current.Offset * 2 * 3.141596f);
                DependencyProperty colorProperty = StopColors[i];
                SetValue(colorProperty, current == null ? Color.FromArgb(0, 0, 0, 0) : current.Color);
            }
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        public Point CenterPoint
        {
            get
            {
                return ((Point)(this.GetValue(CenterPointProperty)));
            }
            set
            {
                this.SetValue(CenterPointProperty, value);
            }
        }
        public GradientStopCollection GradientStops
        {
            get { return (GradientStopCollection)GetValue(GradientStopsProperty); }
            set
            {
                SetValue(GradientStopsProperty, value);
            }
        }
    }
