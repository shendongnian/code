    public class ItemCountMultiConverter : IMultiValueConverter 
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
                return DependencyProperty.UnsetValue;
            var dateToCount = values[0] as DateTime?;
            var source = values[1] as IEnumerable<Patient>;
            if (!dateToCount.HasValue || source == null)
                return DependencyProperty.UnsetValue;
           
            source.Count(patient => 
                patient.Haemogram.Any(haemogram => haemogram.Date == dateToCount)
                || patient.UrineAnalysis.Any(urine => urine.Date == dateToCount)
                || patient.BloodChemistry.Any(blood => blood.Date == dateToCount)
            );
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
