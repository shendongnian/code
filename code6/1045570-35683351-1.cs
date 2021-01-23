        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .RegisterEntityMapping<Card, CardMapping>()
                .RegisterEntityMapping<User, UserMapping>();
        }
