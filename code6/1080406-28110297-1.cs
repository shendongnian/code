    public HardCodedUserService : ICurrentUserService
    {
        public int? GetUserId()
        {
            return 1;
        }
    }
