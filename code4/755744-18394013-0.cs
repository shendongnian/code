        internal class OpenTSDBResponse
        {
            [JsonProperty("metric")]
            public string Metric { get; set; }
            [JsonProperty("tags")]
            public Tags Tags { get; set; }
            [JsonProperty("aggregateTags")]
            public string[] AggregateTags { get; set; }
            [JsonProperty("dps")]
            public Dictionary<string,double> TimeValues { get; set; }
        }
