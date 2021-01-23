    public class BankMap : EntityTypeConfiguration<Bank>
    {
        public BankMap()
        {
            this.HasKey(b => b.KeyB);
        }
    }
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(u => u.KeyU);
            this.HasOptional(u => u.Bank)
                .WithMany()
                .Map(c => c.MapKey("KeyB"));
        }
    }
