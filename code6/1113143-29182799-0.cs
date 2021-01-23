    public class CurriculumItemsSourceConverter : IValueConverter
    {   
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ObservableCollection<Curriculum> curriculumList = value as ObservableCollection<Curriculum>;
            return curriculumList.SelectMany(c => c.BlocList);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }   
