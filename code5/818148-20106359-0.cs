    public class EnrollmentStateEnumConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (string.IsNullOrEmpty(reader.Value.ToString()))
                return EnrollmentState.Incomplete;
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
    [JsonConverter(typeof(EnrollmentStateEnumConverter))]
    public enum EnrollmentState
    {
        [EnumMember(Value = "incomplete")]
        Incomplete,
        [EnumMember(Value = "actionNeeded")]
        ActionNeeded,
        [EnumMember(Value = "complete")]
        Complete
    }
