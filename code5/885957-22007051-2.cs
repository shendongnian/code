    public class Context
    {
        public IQueryable<Group> Groups { get; set; }
        public IQueryable<RuleInstance> Rules { get; set; }
        public IQueryable<RuleInstanceCurrentMembershipCacheItem> CurrentMembership { get; set; }
    }
