    protected override void Seed(BlogContext blogContext)
        {
            AutomaticMigrationsEnabled = true;
            blogContext.Configuration.LazyLoadingEnabled = true;
            //Add seed classes here!    
        }
