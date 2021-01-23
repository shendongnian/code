    public class LegalDocument
    {
        public virtual int Id { get; set; }
        public virtual ICollection<LegalDocument> LegalDocuments { get; set; }
    }
    public class EFContext : DbContext
    {
        public DbSet<LegalDocument> LegalDocuments { get; set; }
    }
