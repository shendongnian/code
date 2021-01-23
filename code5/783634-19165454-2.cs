    public class ObjA
    {
        public int Id { get; set; }
        public string OtherStuff { get; set; }
        public ObjB MyChild { get; set; }
    }
    public class ObjB
    {
        public int Id { get; set; }
        public string OtherStuff { get; set; }
        [JsonConverter(typeof(IdOnlyConverter))]
        public ObjA MyParent { get; set; }
    }
