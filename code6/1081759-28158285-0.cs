    [MetadataType(typeof(Event))]
    public class BaseEventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
