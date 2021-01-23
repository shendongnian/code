    public static class DatabaseConfig
    {
        private static IGenericRepository<Membership> _membershipRepository = new GenericRepository<Membership>();
        private static IGenericRepository<Profile> _profileRepository = new GenericRepository<Profile>();
    
        public static void CreateIndex()
        {
            _membershipRepository.CreateIndex(new string[] { "UserName" });
            _profileRepository.CreateIndex(new string[] { "Email" });
            ... more code ...
        }
    }
