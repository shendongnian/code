    public class Token
    {
        public string TokenId { get; set; }
        public string TokenValue { get; set; }
        public int Active { get; set; }
        public DateTime Fecalt { get; set; }
        public virtual Users User { get; set; }
    }
    public class UserConfiguration : EntityTypeConfiguration<Users>
    {
        public UserConfiguration()
            : base()
        {
            HasKey(p => p.UserId);
            Property(e => e.Username)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(50);
            Property(e => e.Password)
                 .IsUnicode(false)
                 .IsRequired()
                 .HasMaxLength(50);
            Property(a => a.Active).IsRequired();
            Property(d => d.RegDate).IsRequired();
            
        }
    }
    public class TokenConfiguration : EntityTypeConfiguration<Token>
    {
        public TokenConfiguration()
        {
            HasKey(p => p.TokenId);
            Property(p => p.TokenId).HasMaxLength(50);
            Property(p => p.TokenValue).HasColumnName("Token").IsRequired().HasMaxLength(500);
            Property(p => p.Active).IsRequired();
            Property(p => p.Fecalt).IsRequired();
            HasRequired(d => d.User).WithOptional(d => d.Token).Map(m => m.MapKey("UserId"));
            ToTable("Tokens");
        }
    }
