    using System;
    using System.Windows;
    using System.Windows.Media.Animation;
    namespace ImagesSwitcher
    {
        class MarginAnimation : AnimationTimeline
        {
            protected override Freezable CreateInstanceCore()
            {
                return new MarginAnimation();
            }
        public override Type TargetPropertyType => typeof(Thickness);
        private double GetContrast(double dTo,double dFrom,double process)
        {
            if (dTo < dFrom)
            {
                return dTo + (1 - process) * (dFrom - dTo);
            }
            return dFrom + (dTo - dFrom) * process;
        }
        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            if (!From.HasValue || !To.HasValue || animationClock.CurrentProgress == null) return null;
            var progress = animationClock.CurrentProgress.Value;
            if (progress.Equals(0)) return null;
            if (progress.Equals(1)) return To.Value; 
            var fromValue = From.Value;
            var toValue = To.Value;
            var l = GetContrast(toValue.Left ,fromValue.Left, progress);
            var t = GetContrast(toValue.Top, fromValue.Top, progress);
            var r = GetContrast(toValue.Right, fromValue.Right, progress);
            var b = GetContrast(toValue.Bottom, fromValue.Bottom, progress);
            return new Thickness(l,t,r,b);
        }
        public Thickness? To
        {
            set => SetValue(ToProperty, value);
            get => (Thickness)GetValue(ToProperty);
        }
        public static DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(Thickness), typeof(MarginAnimation), new PropertyMetadata(null));
        public Thickness? From
        {
            set => SetValue(FromProperty, value);
            get => (Thickness)GetValue(FromProperty);
        }
        public static DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(Thickness), typeof(MarginAnimation), new PropertyMetadata(null));
    }
}
