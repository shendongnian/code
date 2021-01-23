    public class AccountMap
    {
        public void MapEntity(EntityTypeBuilder<Account> entityBuilder)
        {
            base.MapEntity(entityBuilder);
            entityBuilder.HasKey(x => x.AccountId);
            entityBuilder.Property(x => x.AccountId).IsRequired().HasDefaultValueSql("newid()");
            entityBuilder.Property(x => x.Username).IsRequired().HasMaxLength(50);
        }
    }
