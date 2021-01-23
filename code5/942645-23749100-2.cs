    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var Selecteditems = value as List<object>;
        var MyTypeList = Selecteditems.Select((i) => System.Convert.ChangeType(i, parameter as Type)).ToList();
        return MyTypeList;
    }
