    public class TrendDatas
    {
        // ... snip ...
        [XmlElement(IsNullable = true)]
        public int? Id { get; set; }
        public bool ShouldSerializeId() { return Id.HasValue; }
        // ... snip ...
    }
 
