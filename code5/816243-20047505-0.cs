    public class ContractMap : EntityTypeConfiguration<Contract> {
      public ContractMap() {
        this.HasKey(x => x.Id);
    
        this.HasMany(x => x.PaymentRequests)
            .WithRequired(pr => pr.Contract);
        this.HasMany(x => x.Bills)
            .WithRequired(b => b.Contract);
      }
    }
    
    public class BillMap : EntityTypeConfiguration<Bill> {
      public BillMap() {
        this.HasKey(x => x.Id);
    
        this.HasRequired(x => x.Contract);
        this.HasMany(x => x.PaymentRequests)
            // change this to .WithOptional( x => x.Bill )
            .WithOptional(x => x.Bill);
      }
    }
    
    public class PaymentRequestMap : EntityTypeConfiguration<PaymentRequest> {
      public PaymentRequestMap() {
        this.HasKey(x => x.Id);
    
        this.HasRequired(x => x.Contract);
        this.HasOptional(x => x.Bill);
      }
    }
