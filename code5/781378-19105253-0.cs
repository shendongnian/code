    public class DateCell : ChartCell
    {
        [JsonIgnore]
        public DateTime Value { get; set; }
    
        [JsonProperty(PropertyName = "date")]
        public override object DataValue
        {
            get
            {
                return string.Format("Date({0},{1},{2})", this.Value.Year, this.Value.Month - 1, this.Value.Day);
            }
        }
    }
