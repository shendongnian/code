    [TypeConverter(typeof(MyPropertyConverter))]
    public struct MyProperty
    {
        ...
    }
    public class MyPropertyConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, Object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection collection = TypeDescriptor.GetProperties(typeof(MyProperty));
            // Reorganize the collection of sub-properties
            return collection;
        }
        // overrides of the methods: CanConvertTo, ConvertTo, CanConvertFrom, ConvertFrom etc
    }
