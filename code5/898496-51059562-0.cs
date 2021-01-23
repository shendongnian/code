    public class LineMultiplierConverter : IValueConverter
    {
        private int m_lineIndex = 0;
        Line m_curentLine = null;
        /// <summary>
        /// Base value that will be multiplied
        /// </summary>
        public double BaseValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var line = value as Line;
            if (line == null)
                return BaseValue;
            bool newLine = line != m_curentLine; //check the reference because this method will called twice on one element by my binding
            if (newLine)
            {
                m_lineIndex++;
                m_curentLine = line; 
            }
            return BaseValue * m_lineIndex;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
