    public class DateTimeSerializationOptionsConvention : ConventionBase, IMemberMapConvention
    {
        private readonly DateTimeKind _kind;
        private readonly BsonType _representation;
        public DateTimeSerializationOptionsConvention(DateTimeKind kind, BsonType representation)
        {
            _kind = kind;
            _representation = representation;
        }
        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.MemberType == typeof(DateTime))
            {
                memberMap.SetSerializationOptions(new DateTimeSerializationOptions(_kind, _representation));
            }
        }
    }
