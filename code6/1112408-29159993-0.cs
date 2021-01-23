    public class CompanyMap : JoinedSubclassMapping<Company>
    {
        public CompanyMap()
        {
            Key(k =>
            {
                k.Column("PartyId");
                // or...
                k.Column(c =>
                {
                    c.Name("PartyId");
                    // etc.
                });
    
                k.ForeignKey("party_fk");
                k.NotNullable(true);
                k.OnDelete(OnDeleteAction.Cascade); // or OnDeleteAction.NoAction
                k.PropertyRef(x => x.CompanyName);
                k.Unique(true);
                k.Update(true);
            });
    
            Property(x => x.CompanyName);
        }
    }
