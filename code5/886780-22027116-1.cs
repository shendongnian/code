    public sealed class AuftaktResult
    {
        // ...
        [JsonProperty("click_marks")]
        [JsonConverter(typeof(ObjectToArrayConverter<ClickMark>))]
        public ClickMark[] ClickMarks { get; set; }
    }
