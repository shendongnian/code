        internal Client GetClient(string userId, bool lazyLoadingEnabled = true)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                var client = context
                            .Client
                            .Include(s => s.ScholarLevelDetails)
                            .Include(s => s.JobsExperiences)
                            .Include(s => s.CapacitationCourses)
                            .Include(s => s.Relatives)
                            .FirstOrDefault(s => s.ApplicationUserId == userId);
                return client;
            }
        }
