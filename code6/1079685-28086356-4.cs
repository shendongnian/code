    sealed class MyContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<WorkRelationship> WorkRelationships { get; set; }
        public IEnumerable<Person> GetColleagues(int personId)
        {
            List<WorkRelationship> relationships =
                WorkRelationships
                .Include(x => x.Myself)
                .Include(x => x.Colleague)
                .Where(x => x.MyselfId == personId || x.ColleagueId == personId)
                .ToList();
            foreach (WorkRelationship relationship in relationships)
            {
                if (relationship.Myself.Id == personId)
                {
                    yield return relationship.Colleague;
                }
                else if (relationship.Colleague.Id == personId)
                {
                    yield return relationship.Myself;
                }
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
