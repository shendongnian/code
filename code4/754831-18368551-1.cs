    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value.GetType() != typeof(int)) return false; // <--------
        string answer = "";
        switch ((int)value)
        {
            case 1:
            {
                answer = DatesInfo.Instance.MonthsNames[0];
                break;
            }            
            default:
            {
                break;
            }
        }   
        return answer;
    }
