    public static class EntityConfigExtensions
    {
        public static EntityTypeConfiguration<TEntity> Prop<TEntity, TProp>(this EntityTypeConfiguration<TEntity> self, Expression<Func<TEntity, TProp>> propExpression) where TEntity : class where TProp : struct
        {
            self.Property(propExpression);
            return self;
        }
        public static EntityTypeConfiguration<TEntity> RequiredProp<TEntity, TProp>(this EntityTypeConfiguration<TEntity> self, Expression<Func<TEntity, TProp>> propExpression) where TEntity : class where TProp : struct
        {
            self.Property(propExpression).IsRequired();
            return self;
        }
        // etcetera for other frequently used configs
        // ...
        // And, borrowing from David: a catch-all for the rest
        public static EntityTypeConfiguration<TEntity> Configure<TEntity, TProp>(this EntityTypeConfiguration<TEntity> self, Action<EntityTypeConfiguration<TEntity>> configAction) where TEntity : class
        {
            configAction(self);
            return self;
        }
    }
