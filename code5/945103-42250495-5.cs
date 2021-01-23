    public class OrderModelUriConverter : TypeConverter
    {
        private static readonly Type StringType = typeof (string);
    
        public OrderModelUriConverter()
        {
        }
    
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == StringType)
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
    
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var str = value as string;
            if (str != null)
            {
                var parser = new OrderParameterParser()
                OrderParameter orderParameter;
                if (parser.TryParse(str, out orderParameter))
                {
                    return orderParameter;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
