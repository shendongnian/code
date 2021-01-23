    public object Convert<TData>(TData value, object parameter, System.Globalization.CultureInfo culture)
			where TData : class
		{
			TData convertedObject = parameter as TData;
			if (convertedObject == null)
				return false;
			else
				return value == convertedObject;
		}
