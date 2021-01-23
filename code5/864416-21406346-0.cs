    public class BooleanConverter : System.ComponentModel.BooleanConverter
    {
        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            try
            {
                byte b = Convert.ToByte(value);
                return b == 0 || b == 1 || base.IsValid(context, value);
            }
            catch
            {
                return base.IsValid(context, value);
            }
        }
    }
