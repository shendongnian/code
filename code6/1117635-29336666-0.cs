    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Entity<Recipe>()
                    .HasMany(c => c.Categories).WithMany(i => i.Recipes)
                    .Map(t => t.MapLeftKey("RecipeID")
                            .MapRightKey("CategoryID")
                            .ToTable("ReceipeCategory")
                            );
