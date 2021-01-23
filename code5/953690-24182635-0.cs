    [DataContract]
    public class Test
    {
        public DateTime xaaaaaa { get; set; }
        [DataMember(Name = "xaaaaaa")]
        private string HiredForSerialization { get; set; }
        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            this.HiredForSerialization = JsonConvert.SerializeObject(this.xaaaaaa).Replace('"',' ').Trim();
        }
        [OnDeserialized]
        void OnDeserialized(StreamingContext ctx)
        {
            this.xaaaaaa = DateTime.Parse(this.HiredForSerialization);
        }
    }
