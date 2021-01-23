    using Preset = Tuple<string, string>;
    public class MyObject : DependencyObject
    {
        private readonly IList<Tuple<string, string>> _presets = new List<Preset> {
            new Preset("1", "good"),
            new Preset("2", "bad"),
        };
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(string), typeof(MyObject),
            new PropertyMetadata(null,
                (o, e) => ((MyObject)o).ValuePropertyChanged((string)e.NewValue)));
        private static readonly DependencyProperty FriendlyValueProperty = DependencyProperty.Register(
            "FriendlyValue", typeof(string), typeof(MyObject),
            new PropertyMetadata(null,
                (o, e) => ((MyObject)o).FriendlyValuePropertyChanged((string)e.NewValue)));
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public string FriendlyValue
        {
            get { return (string)GetValue(FriendlyValueProperty); }
            set { SetValue(FriendlyValueProperty, value); }
        }
        private void ValuePropertyChanged (string newValue)
        {
            var preset = _presets.FirstOrDefault(p => p.Item1 == newValue);
            FriendlyValue = preset != null ? preset.Item2 : newValue;
        }
        private void FriendlyValuePropertyChanged (string newValue)
        {
            var preset = _presets.FirstOrDefault(p => p.Item2 == newValue);
            Value = preset != null ? preset.Item1 : newValue;
        }
    }
