    public class BarConverter : ExpandableObjectConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                 Bar _Bar = (Bar) value;
                 return _Bar.Name;
            }
        }
