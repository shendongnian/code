    public class PortfolioMap : BaseEntityTypeConfiguration<Portfolio>
    {
        public PortfolioMap()
        {
            //Primary key
            HasKey(t => t.Id);
            //Map schema name and table
            ToTable("Portfolio", SchemaConstants.Component);
            //Set property mapping explicit if needed
            Property(t => t.Name).HasMaxLength(150).IsRequired();
            
            //Foreign key relationships
             HasRequired(t => t.Projects).WithRequiredPrincipal(); <<--- Line causing the error
            //Other constraints
        }
    }
