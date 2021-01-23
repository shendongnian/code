    [MetadataType(typeof(ImportSetMetaData))]
    public partial class ImportSet
    {
    }
    public class ImportSetMetaData
    {
        [StringLength(maximumLength: 32)]
        public string Segment { get; set; }
