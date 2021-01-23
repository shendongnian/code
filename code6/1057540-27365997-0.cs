    public class CenterMapping : EntityTypeConfiguration<Center>
    {
        public CenterMapping()
        {
            HasKey(x => x.ID);
        }
    }
