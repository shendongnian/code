    class Example2
    {
        [JsonProperty (ItemConverterType = typeof(StringEnumConverter))]
        public IList<Size> Sizes { get; set; }
    }
