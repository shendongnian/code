    public enum NamedSize
	{
	    Default = 0,
		Micro = 1,
		Small = 2,
		Medium = 3,
		Large = 4
	}
    public class FontSizeConverter : TypeConverter, IExtendedTypeConverter
	{
		object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
		{
			if (value != null)
			{
				double size;
				if (double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out size))
					return size;
				NamedSize namedSize;
				if (Enum.TryParse(value, out namedSize))
				{
					Type type;
					var valueTargetProvider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
					type = valueTargetProvider != null ? valueTargetProvider.TargetObject.GetType() : typeof(Label);
					return Device.GetNamedSize(namedSize, type, false);
				}
			}
			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(double)));
		}
		public override object ConvertFromInvariantString(string value)
		{
			if (value != null)
			{
				double size;
				if (double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out size))
					return size;
				NamedSize namedSize;
				if (Enum.TryParse(value, out namedSize))
					return Device.GetNamedSize(namedSize, typeof(Label), false);
			}
			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(double)));
		}
	}
