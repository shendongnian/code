    public class DealMapping : EntityTypeConfiguration<Deal>
    {
       public DealMapping()
       {
          ToTable("Deals");
          HasKey(c=>c.DealId);
          HasOptional(d => d.Closer).WithMany(s=>s.ClosedDeals).HasForeignKey(p=>p.CloserId);
          HasOptional(d => d.Negotiator).WithMany(s=>s.NegotiatedDeals).HasForeignKey(p=>p.NegotiatorId);
       }
    }
