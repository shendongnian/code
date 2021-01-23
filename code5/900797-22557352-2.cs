    public class ReaderMap : SubClassMap<Reader>
    {
        public ReaderMap()
        {
            this.DiscriminatorValue("Reader");
            this.Map(x => x.Email);
        }
    }
