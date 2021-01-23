    public class CustomDateTimeConverterJalali : DateTimeConverterBase
    {
        //I had no use for WriteJson section, i just wrote it, so i do not guarantee it working
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            var nullableType = Nullable.GetUnderlyingType(value.GetType());
            var isNullable = nullableType != null;
            DateTime date;
            if (isNullable)
                date = ((DateTime?) value).Value;
            else
                date = (DateTime) value;
            PersianCalendar pc = new PersianCalendar();
            writer.WriteValue(pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + pc.GetDayOfMonth(date));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //this should likely be null, but since the provider json returned empty string, it was unavoidable... (i'm not sure what we will read using reader, if data is actually null on the json side, feel free to experiment 
            if (string.IsNullOrWhiteSpace((string) reader.Value))
            {
                return null;
            }
            var strDate = reader.Value.ToString();
            PersianCalendar pc = new PersianCalendar();
            var dateParts = strDate.Split('/');
            DateTime date = pc.ToDateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]),
                0, 0, 0, 0);
            return date;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);//DateTime=>true | DateTime?=>true
        }
    }
