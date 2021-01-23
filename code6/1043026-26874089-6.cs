    public class Foo
    {
        [JsonProperty]
        internal int num1 { get; set; }
        [JsonProperty]
        internal double num2 { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Description))
                return Description;
            return base.ToString();
        }
    }
