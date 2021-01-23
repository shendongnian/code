    public class MoneyFormatter : ConverterBase
    {
        public override object FieldToString(string fieldValue)
        {
            var val = fieldValue == null ? 0 : Convert.ToDecimal(fieldValue); 
            return "$" + val.ToString(CultureInfo.InvariantCulture); 
        }
    }
    [FieldOrder(3)]
    [FieldConverter(typeof(MoneyFormatter))]
    public double price;
