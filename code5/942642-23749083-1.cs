    public Type ConvertType { get; set; }
    public object Convert(object value, Type targetType, object parameter,
                          System.Globalization.CultureInfo culture)
    {
        var type = typeof(List<>).MakeGenericType(ConvertType);
        var methodInfo = typeof(Enumerable).GetMethod("Cast");
        var genericMethod = methodInfo.MakeGenericMethod(ConvertType);
        var convertTypeList = Activator.CreateInstance(type,
                        genericMethod.Invoke(null, new[] { value }));
        return convertTypeList;
    }
