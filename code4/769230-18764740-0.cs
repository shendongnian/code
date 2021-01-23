    public class BindingConverter : ExpressionConverter
    {
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
        if (destinationType == typeof(MarkupExtension))
        {
            BindingExpression bindingExpression = value as BindingExpression;
            if (bindingExpression == null)
            {
                throw new FormatException("Expected binding, but didn't get one");
            }
            return bindingExpression.ParentBinding;
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
