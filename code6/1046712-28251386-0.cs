    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var result = "Transparent";
			if (!(values[0] is DateTime))
				return result;
			ObservableCollection<Log> collection = null;
			if (values[1] is ObservableCollection<Log>)
				collection = (ObservableCollection<Log>) values[1];
			if (collection != null)
			{
				foreach (var log in collection.Where(log => (DateTime) values[0] == log.Date.Date))
				{
					result = log.BackgroundColor;
					break;
				}
			}
			return new SolidColorBrush((Color) ColorConverter.ConvertFromString(result));
		}
    <Style TargetType="{x:Type Border}">
	<Setter Property="BorderBrush">
        <Setter.Value>
            <MultiBinding Converter="{StaticResource DayColorConv}" FallbackValue="Transparent">
                <Binding/>
                <Binding Path="CurrentLogs" RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType={x:Type panels:Schedule}}"/>
            </MultiBinding>
        </Setter.Value>
    </Setter>
