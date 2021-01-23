        [JsonObject]
        public class MailItem
        {
            public int ID { get; set; }
            public Boolean Status { get; set; }
            [JsonIgnore]
            public String SomethingToNotInclude { get; set; }
        }
