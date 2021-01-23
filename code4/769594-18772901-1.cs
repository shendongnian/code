    public sealed class BadgeService : IBadgeService
    {
        private readonly IBadgeRepository _badgeRepository;
        private readonly List<Badge> _badges = new List<Badge>();
        
        public BadgeService(IBadgeRepository badgeRepository)
        {
            _badgeRepository = badgeRepository;
        }
        
        public async Task<IList<Badge>> GetAll()
        {
            if(!_badges.Any())
            {
                var badges = _badgeRepository.GetAll();
                _badges.AddRange(badges);
            }
            
            return Task.FromResult(_badge);
        }
        
        public async Task Update(Badge badge)
        {
            if(!_badges.Contains(badge))
            {
                _badges.Add(badge);
            }
            else
            {
                var index = _badges.IndexOf(badge);
                _badges[index] = badge;
            }
            
            _badgeRepository.Save(_badges);
        }
    }
