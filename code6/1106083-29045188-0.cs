    public class DynamoNullableDateConverter : IPropertyConverter
    {
        public DynamoDBEntry ToEntry(object value)
        {
            DynamoDBEntry entry = new Primitive { Value = null };
            //Format - 2015-03-12T20:24:07.647Z
            if (value != null)
                entry = new Primitive { Value = ((DateTime)value).ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ") };
            return entry;
        }
        public object FromEntry(DynamoDBEntry entry)
        {
            Primitive primitive = entry as Primitive;
            if (primitive != null)
            {
                var dtString = primitive.Value.ToString();
                var value = DateTime.Parse(dtString, null, System.Globalization.DateTimeStyles.RoundtripKind);
                return value;
            }
            else 
                return (DateTime?)null;
        }
    }
