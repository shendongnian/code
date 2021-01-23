    /// <summary>
    /// Wrapper class for an unlimited size string property 
    /// to allow for lazy loading with Entity Framework.
    /// </summary>
    public class Text
    {
        [MaxLength]
        public string Value { get; set; }
        public static implicit operator string(Text val)
        {
            return val.Value;
        }
        public static implicit operator Text(string val)
        {
            return new Text { Value = val };
        }
        public override string ToString()
        {
            return Value;
        }
    }
