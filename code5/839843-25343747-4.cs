        class DoubleConverterEx : DoubleConverter
        {
            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string)
                {
                    string text = ((string)value).Trim();
                    // Use the InvariantCulture, which accepts ',' for separator
                    culture = CultureInfo.InvariantCulture;
                    NumberFormatInfo formatInfo = (NumberFormatInfo)culture.GetFormat(typeof(NumberFormatInfo));
                    return Double.Parse(text, NumberStyles.Number, formatInfo);
                }
                return base.ConvertFrom(value);
            }
        }
