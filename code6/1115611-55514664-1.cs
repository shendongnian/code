        public static class ModelBuilderExtension
        {
            public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder, Expression<Func<TInterface, bool>> expression)
            {
                var entities = modelBuilder.Model
                    .GetEntityTypes()
                    .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
                    .Select(e => e.ClrType);
                foreach (var entity in entities)
                {
                    var newParam = Expression.Parameter(entity);
                    var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);    
                    modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
                }
            }
        }
        // Default method inside the DbContext or your default Context
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            modelBuilder.Entity<Blog>();
            modelBuilder.Entity<Post>();
            builder.ApplyGlobalFilters<IDelete>(e => e.IsDeleted == false);
        }
