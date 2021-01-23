	class StringArrayConverter : TypeConverter
	{
		private const string delimiter = "#@#";
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string[]) || base.CanConvertTo(context, destinationType);
		}
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			string v = value as string;
			return v == null ? base.ConvertFrom(context,culture,value) : v.Split(new[] {delimiter}, StringSplitOptions.RemoveEmptyEntries);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			string[] v = value as string[];
			if (destinationType != typeof(string) || v == null)
			{
				return base.ConvertTo(context, culture, value,destinationType);
			}
			return string.Join(delimiter, v);
		}
	}
