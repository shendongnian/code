    public class NoteOctaveConverter : IValueConverter
    {
        private const double _dotDiameter = 3;
        private readonly Thickness _dotMargin = new Thickness(0.25);
        private SolidColorBrush _dotFill;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int octave = (int)value;
            List<DotMockup> dots = new List<DotMockup>();
            if ((octave > 0 && parameter as string == "TOP") || (octave < 0 && parameter as string == "BOT"))
            {
                _dotFill = Brushes.Black;
            }
            else
            {
                _dotFill = Brushes.Transparent;
            }
            for (int i = 0; i < Math.Abs(octave); i++)
            {
                dots.Add(new DotMockup());
                dots[i].Diameter = _dotDiameter;
                dots[i].Margin = _dotMargin;
                dots[i].Fill = _dotFill;
            }
            return dots;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
