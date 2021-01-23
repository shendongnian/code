    public static MentorContextExtensions
    {
        public static InterestEntity ByAptitudeId(
            this IQueryable<InterestEntity> queryable, 
            int aptitudeId)
        {
            return queryable.SingleOrDefault(x => x.AptitudeId == aptitudeId);
        }
    }
