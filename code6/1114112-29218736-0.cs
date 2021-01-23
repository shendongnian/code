    public class SignalColorExtension : MarkupExtension
    {
        public SignalColor IncomingSignalColor
        {
            get;
            set;
        }
        public SignalColorExtension() { }
        public SignalColorExtension(string color)
        {
            SignalColor outColor;
            if (! SignalColor.TryParse(color,true,out outColor))
                IncomingSignalColor = SignalColor.None;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var host = target.TargetObject as FrameworkElement;
            if (host != null && IncomingSignalColor != SignalColor.None)
            {
                var colorResourse = host.TryFindResource(IncomingSignalColor.ToString());
                return colorResourse;
            }
            return DependencyProperty.UnsetValue;
        }
    }
