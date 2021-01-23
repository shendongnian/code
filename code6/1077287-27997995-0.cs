    public object Convert(
        object value, Type targetType, object parameter, string language)
    {
        double pkr;
        double dollar = 0.0;
        if (double.TryParse(value.ToString(), out pkr))
        {
            dollar = pkr * 0.0099;
        }
        return dollar; 
    }
