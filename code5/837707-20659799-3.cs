    public abstract class BaseEntity
    {
        [ConcurrencyCheck] 
        [Timestamp]
        public byte[] Version { get; set; }
        // can also do this globally in FluentAPI with custom EntityTypeConfiguration
    }
    public class SomeEntity : BaseEntity
    {
        public int ID { get; set; }
        public string SomeProperty { get; set; }
    }
