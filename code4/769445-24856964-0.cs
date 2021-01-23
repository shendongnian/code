    public class StaffNameToBackgroundColourConverter : IValueConverter
    {
    public object Convert(object value, Type targetType, object parameter, CultureInfo 
     culture)
    {
        var staff = (Staff)value;
        if (staff.Forename == "Donald" && staff.Surname == "Duck")
        {
            return new SolidColorBrush(Colors.Yellow);
            
        }
        else
        {
            return new SolidColorBrush(Colors.White);
        }
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
    }
