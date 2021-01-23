    public class UserCountResult
    {
        [JsonIgnore]
        public DateTime? date { get; set; }
        [JsonProperty("date")]
        public string DateAsString
        {
            get
            {
                return date != null ? date.Value.ToString("dd.MM.yyyy") : null;
            }
            set
            {
                date = string.IsNullOrEmpty(value) ? default(DateTime?) : DateTime.ParseExact(value, "dd.MM.yyyy", null);
            }
        }
        
        public int users { get; set; }
        public int visits { get; set; }
    }
