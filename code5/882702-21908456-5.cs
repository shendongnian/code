    class Contact
    {
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
    }
