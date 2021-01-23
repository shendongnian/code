    public enum PossibleKeys
    {
        Key1,
        Key2,
        Key3
    }
    public class KeyMetadata
    {
        public PossibleKeys Id { get; set; }
        public string Description { get; set; }
        public SomeOtherClass SomethingAttributesCantHandle { get; set; }
    }
    private static readonly IReadOnlyDictionary<PossibleKeys, KeyMetadata> KeyMetadataLookup;
    static EnumContainerClass()
    {
        Dictionary<PossibleKeys, KeyMetadata> metadata = new Dictionary<PossibleKeys, KeyMetadata>();
        metadata.Add(PossibleKeys.Key1, new KeyMetadata { Id = PossibleKeys.Key1, Description = "First Item" });
        metadata.Add(PossibleKeys.Key2, new KeyMetadata { Id = PossibleKeys.Key2, Description = "Second Item" });
        metadata.Add(PossibleKeys.Key3, new KeyMetadata { Id = PossibleKeys.Key3, Description = "Third Item" });
        KeyMetadataLookup = new ReadOnlyDictionary<PossibleKeys, KeyMetadata>(metadata);
    }
