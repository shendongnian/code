    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
            .HasMany(a => a.RelatedArticles)
            .Map(t => t.MapLeftKey("articleId")
                .MapRightKey("relatedArticleId")
                .ToTable("RelatedArticles"));
    }
