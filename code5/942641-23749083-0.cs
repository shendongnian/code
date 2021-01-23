    public Type ConvertType { get; set; }
    public object Convert(object value, Type targetType, object parameter,
                          System.Globalization.CultureInfo culture)
    {
        var type = typeof(List<>).MakeGenericType(ConvertType);
        var convertTypeList = Activator.CreateInstance(type, value);
        return convertTypeList;
    }
    <myns:SelectedTiposDocsToList x:Key="Conv" ConvertType="{x:Type myns:MyType}" />
