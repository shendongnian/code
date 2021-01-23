    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    
    namespace MyProject
    {
        public class BloggingContextFactory : IDbContextFactory<BloggingContext>
        {
            public BloggingContext Create()
            {
                var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
                optionsBuilder.UseSqlServer("connection_string");
    
                return new BloggingContext(optionsBuilder.Options);
            }
        }
    }
