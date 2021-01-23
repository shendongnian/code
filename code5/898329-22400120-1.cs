    public sealed class FeatureArticleMap : EntityTypeConfiguration<FeatureArticle>
    {
        public FeatureArticleMap()
        {
            // Primary Key
            HasKey(o => o.Id);
            // Properties
            Property(o => o.Order).IsRequired();
            // Table & Column Mappings
            ToTable("FeatureArticle");
            Property(o => o.Id).HasColumnName("Id");
            Property(o => o.Order).HasColumnName("Order");
            Property(o => o.ArticleId).HasColumnName("ArticleId");
            // Relationships
            HasRequired(o => o.Article)
                .WithMany(o => o.FeatureArticles)
                .HasForeignKey(d => d.ArticleId);
        }
    }
    public sealed class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            // Primary Key
            HasKey(o => o.Id);
            // Properties
            Property(o => o.Name).IsRequired().HasMaxLength(255);
            Property(o => o.Content).IsRequired();
            // Table & Column Mappings
            ToTable("Article");
            Property(o => o.Name).HasColumnName("Name");
            Property(o => o.Content).HasColumnName("Content");
        }
    }
