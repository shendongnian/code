    class MyData
    {
        [JsonConverter(typeof(UnknownObjectConverter))]
        public object UserProp { get; set; }
    }
