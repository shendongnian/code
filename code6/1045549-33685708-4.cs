    public class AccountMap
    {
        public AccountMap(EntityTypeBuilder<Account> entityBuilder)
        {
            entityBuilder.HasKey(x => x.AccountId);
            entityBuilder.Property(x => x.AccountId).IsRequired();
            entityBuilder.Property(x => x.Username).IsRequired().HasMaxLength(50);
        }
    }
