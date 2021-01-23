    public class Class1Converter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, 
                                            Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context,
                                          Type destinationType)
        {
            if(destinationType == typeof(Class1))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context,
                                           System.Globalization.CultureInfo culture, 
                                           object value)
        {
            var stringValue = value as string;
            if(stringValue != null)
            {
                                return new Class1
                    {
                        Naming = (NamingConvention)Enum.Parse(typeof(NamingConvention), stringValue)
                    };
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
