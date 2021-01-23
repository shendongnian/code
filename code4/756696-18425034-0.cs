    public static class EntityConfigExtensions
    {
        public static EntityTypeConfiguration<TEntity> Prop<TEntity, TProp>(this EntityTypeConfiguration<TEntity> self, Expression<Func<TEntity, TProp>> propExpression)
        {
            self.Property(propExpression);
            return self;
        }
        public static EntityTypeConfiguration<TEntity> RequiredProp<TEntity, TProp>(this EntityTypeConfiguration<TEntity> self, Expression<Func<TEntity, TProp>> propExpression)
        {
            self.Property(propExpression).IsRequired();
            return self;
        }
        // etcetera for other frequently used configs
    }
