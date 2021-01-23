        public AppDbContext() : base("QualityWebAppDbEntitiesDefault", throwIfV1Schema: false)
        {
        }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
