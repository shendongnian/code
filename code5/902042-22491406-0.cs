    namespace ProjectName.Converters
    {
        [ValueConversion(typeof(bool), typeof(Brush))]
        public class BoolToBrushConverter : IValueConverter
        {
            ...
        }
    }
