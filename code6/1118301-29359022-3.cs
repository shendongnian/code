    public class UTCTimeStampType : TimestampType
        {
            public override object Get(IDataReader rs, int index)
            {
                return ConvertToUtc(base.Get(rs, index));
            }
    
            public override object Get(IDataReader rs, string name)
            {
                return ConvertToUtc(base.Get(rs, name));
            }
    
            public override object FromStringValue(string xml)
            {
                return ConvertToUtc(base.FromStringValue(xml));
            }
    
            private DateTime ConvertToUtc(object value)
            {
                var dateTime = (DateTime) value;
                return new DateTime(dateTime.Ticks).ToUniversalTime();
            }
        }
