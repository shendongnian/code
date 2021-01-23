    public class Article
    {
    public int ArticleId { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }
    public int ModifierId { get; set; }
    
    [InverseProperty("UserArticles")]
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    [InverseProperty("ModifierArticles")]
    [ForeignKey("ModifierId")]
    public virtual User Modifier { get; set; }
    }
    public class User
    {
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    [InverseProperty("User")]
    public virtual List<Article> UserArticles { get; set; }
    [InverseProperty("Modifier")]
    public virtual List<Article> ModifierArticles { get; set; }
    }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasRequired(c => c.User).WithMany(u => u.UserArticles).HasForeignKey(c => c.UserId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Article>().HasRequired(c => c.Modifier).WithMany(u => u.ModifierArticles).HasForeignKey(c => c.ModifierId).WillCascadeOnDelete(false);
          .
          .
          .
          .
        }
