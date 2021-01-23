    public interface IBadgeRepository
    {
        // Save Xml File
        Task Save(IEnumerable<Badge> badges);
        // Load Xml File
        Task<Badge> GetAll();
    }
