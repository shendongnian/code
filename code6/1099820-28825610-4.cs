    public class MyTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            // get existing value
            object existingPropertyValue = context.PropertyDescriptor.GetValue(context.Instance);
            
            // do something useful here
            ...
        }
    }
